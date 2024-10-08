using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

#nullable enable

namespace OpenAI.Assistants;

internal class RunStepCollectionPageToken : ContinuationToken
{
    protected RunStepCollectionPageToken(string threadId, string runId, int? limit, string? order, string? after, string? before)
    {
        ThreadId = threadId;
        RunId = runId;

        Limit = limit;
        Order = order;
        After = after;
        Before = before;
    }

    public string ThreadId { get; }

    public string RunId { get; }

    public int? Limit { get; }

    public string? Order { get; }

    public string? After { get; }

    public string? Before { get; }

    public override BinaryData ToBytes()
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStartObject();
        writer.WriteString("threadId", ThreadId);
        writer.WriteString("runId", RunId);

        if (Limit.HasValue)
        {
            writer.WriteNumber("limit", Limit.Value);
        }

        if (Order is not null)
        {
            writer.WriteString("order", Order);
        }

        if (After is not null)
        {
            writer.WriteString("after", After);
        }

        if (Before is not null)
        {
            writer.WriteString("before", Before);
        }

        writer.WriteEndObject();

        writer.Flush();
        stream.Position = 0;

        return BinaryData.FromStream(stream);
    }

    public static RunStepCollectionPageToken FromToken(ContinuationToken pageToken)
    {
        if (pageToken is RunStepCollectionPageToken token)
        {
            return token;
        }

        BinaryData data = pageToken.ToBytes();

        if (data.ToMemory().Length == 0)
        {
            throw new ArgumentException("Failed to create RunStepsPageToken from provided pageToken.", nameof(pageToken));
        }

        Utf8JsonReader reader = new(data);

        string threadId = null!;
        string runId = null!;
        int? limit = null;
        string? order = null;
        string? after = null;
        string? before = null;

        reader.Read();

        Debug.Assert(reader.TokenType == JsonTokenType.StartObject);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

            string propertyName = reader.GetString()!;

            switch (propertyName)
            {
                case "threadId":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    threadId = reader.GetString()!;
                    break;
                case "runId":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    runId = reader.GetString()!;
                    break;
                case "limit":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.Number);
                    limit = reader.GetInt32();
                    break;
                case "order":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    order = reader.GetString();
                    break;
                case "after":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    after = reader.GetString();
                    break;
                case "before":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    before = reader.GetString();
                    break;
                default:
                    throw new JsonException($"Unrecognized property '{propertyName}'.");
            }
        }

        if (threadId is null || runId is null)
        {
            throw new ArgumentException("Failed to create RunStepsPageToken from provided pageToken.", nameof(pageToken));
        }

        return new(threadId, runId, limit, order, after, before);
    }

    public static RunStepCollectionPageToken FromOptions(string threadId, string runId, int? limit, string? order, string? after, string? before)
        => new(threadId, runId, limit, order, after, before);

    public static RunStepCollectionPageToken? FromResponse(ClientResult result, string threadId, string runId, int? limit, string? order, string? before)
    {
        PipelineResponse response = result.GetRawResponse();
        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string lastId = doc.RootElement.GetProperty("last_id"u8).GetString()!;
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        if (!hasMore || lastId is null)
        {
            return null;
        }

        return new(threadId, runId, limit, order, lastId, before);
    }
}