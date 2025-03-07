/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../common";
import "./custom.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

/** The expiration policy for a vector store. */
model VectorStoreExpirationAfter {
  @doc("""
    Anchor timestamp after which the expiration policy applies. Supported anchors: `last_active_at`.
    """)
  anchor: "last_active_at";

  /** The number of days after the anchor time that the vector store will expire. */
  @minValue(1)
  @maxValue(365)
  days: int32;
}

@doc("""
  A vector store is a collection of processed files can be used by the `file_search` tool.
  """)
model VectorStoreObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
    The object type, which is always `vector_store`.
    """)
  object: "vector_store";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the vector store was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The name of the vector store. */
  name: string;

  /** The total number of bytes used by the files in the vector store. */
  usage_bytes: int32;

  file_counts: {
    /** The number of files that are currently being processed. */
    in_progress: int32;

    /** The number of files that have been successfully processed. */
    completed: int32;

    /** The number of files that have failed to process. */
    failed: int32;

    /** The number of files that were cancelled. */
    cancelled: int32;

    /** The total number of files. */
    total: int32;
  };

  @doc("""
    The status of the vector store, which can be either `expired`, `in_progress`, or `completed`. A status of `completed` indicates that the vector store is ready for use.
    """)
  status: "expired" | "in_progress" | "completed";

  expires_after?: VectorStoreExpirationAfter;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the vector store will expire. */
  @encode("unixTimestamp", int32)
  expires_at?: utcDateTime | null;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the vector store was last active. */
  @encode("unixTimestamp", int32)
  last_active_at: utcDateTime | null;

  ...MetadataPropertyForResponse;
}

model CreateVectorStoreRequest {
  @doc("""
    A list of [File](/docs/api-reference/files) IDs that the vector store should use. Useful for tools like `file_search` that can access files.
    """)
  @maxItems(500)
  file_ids?: string[];

  /** The name of the vector store. */
  name?: string;

  expires_after?: VectorStoreExpirationAfter;

  @doc("""
    The chunking strategy used to chunk the file(s). If not set, will use the `auto` strategy. Only applicable if `file_ids` is non-empty.
    """)
  @extension("x-oaiExpandable", true)
  chunking_strategy?: AutoChunkingStrategyRequestParam | StaticChunkingStrategyRequestParam;

  ...MetadataPropertyForRequest;
}

model UpdateVectorStoreRequest {
  /** The name of the vector store. */
  name?: string | null;

  expires_after?: VectorStoreExpirationAfter | null;
  ...MetadataPropertyForRequest;
}

model ListVectorStoresResponse {
  // Tool customization: add a clear enum enforcement of constrained 'object' label
  object: "list";

  data: VectorStoreObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model DeleteVectorStoreResponse {
  id: string;
  deleted: boolean;
  object: "vector_store.deleted";
}

/** A list of files attached to a vector store. */
model VectorStoreFileObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
    The object type, which is always `vector_store.file`.
    """)
  object: "vector_store.file";

  /** The total vector store usage in bytes. Note that this may be different from the original file size. */
  usage_bytes: int32;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the vector store file was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The ID of the [vector store](/docs/api-reference/vector-stores/object) that the [File](/docs/api-reference/files) is attached to. */
  vector_store_id: string;

  @doc("""
    The status of the vector store file, which can be either `in_progress`, `completed`, `cancelled`, or `failed`. The status `completed` indicates that the vector store file is ready for use.
    """)
  status: "in_progress" | "completed" | "cancelled" | "failed";

  @doc("""
    The last error associated with this vector store file. Will be `null` if there are no errors.
    """)
  last_error: {
    @doc("""
      One of `server_error` or `rate_limit_exceeded`.
      """)
    code: "server_error" | "unsupported_file" | "invalid_file";

    /** A human-readable description of the error. */
    message: string;
  } | null;

  /** The strategy used to chunk the file. */
  @extension("x-oaiExpandable", true)
  chunking_strategy?: StaticChunkingStrategyResponseParam | OtherChunkingStrategyResponseParam;
}

model CreateVectorStoreFileRequest {
  @doc("""
    A [File](/docs/api-reference/files) ID that the vector store should use. Useful for tools like `file_search` that can access files.
    """)
  file_id: string;

  chunking_strategy?: ChunkingStrategyRequestParam;
}

model ListVectorStoreFilesResponse {
  // Tool customization: add a clear enum enforcement of constrained 'object' label
  object: "list";

  data: VectorStoreFileObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model DeleteVectorStoreFileResponse {
  id: string;
  deleted: boolean;
  object: "vector_store.file.deleted";
}

/** A batch of files attached to a vector store. */
model VectorStoreFileBatchObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
    The object type, which is always `vector_store.file_batch`.
    """)
  object: "vector_store.files_batch";

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the vector store files batch was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The ID of the [vector store](/docs/api-reference/vector-stores/object) that the [File](/docs/api-reference/files) is attached to. */
  vector_store_id: string;

  @doc("""
    The status of the vector store files batch, which can be either `in_progress`, `completed`, `cancelled` or `failed`.
    """)
  status: "in_progress" | "completed" | "cancelled" | "failed";

  file_counts: {
    /** The number of files that are currently being processed. */
    in_progress: int32;

    /** The number of files that have been processed. */
    completed: int32;

    /** The number of files that have failed to process. */
    failed: int32;

    /** The number of files that where cancelled. */
    cancelled: int32;

    /** The total number of files. */
    total: int32;
  };
}

model CreateVectorStoreFileBatchRequest {
  @doc("""
    A list of [File](/docs/api-reference/files) IDs that the vector store should use. Useful for tools like `file_search` that can access files.
    """)
  @minItems(1)
  @maxItems(500)
  file_ids: string[];

  chunking_strategy?: ChunkingStrategyRequestParam;
}

// Tool customization: apply custom common base
@doc("""
  This is returned when the chunking strategy is unknown. Typically, this is because the file was indexed before the `chunking_strategy` concept was introduced in the API.
  """)
model OtherChunkingStrategyResponseParam
  extends FileChunkingStrategyResponseParam {
  @doc("""
    Always `other`.
    """)
  type: "other";
}

// Tool customization: apply custom common base
model StaticChunkingStrategyResponseParam
  extends FileChunkingStrategyResponseParam {
  @doc("""
    Always `static`.
    """)
  type: "static";

  static: StaticChunkingStrategy;
}

model StaticChunkingStrategy {
  @doc("""
    The maximum number of tokens in each chunk. The default value is `800`. The minimum value is `100` and the maximum value is `4096`.
    """)
  @minValue(100)
  @maxValue(4096)
  max_chunk_size_tokens: int32;

  @doc("""
    The number of tokens that overlap between chunks. The default value is `400`.
    
    Note that the overlap must not exceed half of `max_chunk_size_tokens`.
    """)
  chunk_overlap_tokens: int32;
}

// Tool customization: apply custom common base
@doc("""
  The default strategy. This strategy currently uses a `max_chunk_size_tokens` of `800` and `chunk_overlap_tokens` of `400`.
  """)
model AutoChunkingStrategyRequestParam
  extends FileChunkingStrategyRequestParam {
  @doc("""
    Always `auto`.
    """)
  type: "auto";
}

// Tool customization: apply custom common base
model StaticChunkingStrategyRequestParam
  extends FileChunkingStrategyRequestParam {
  @doc("""
    Always `static`.
    """)
  type: "static";

  static: StaticChunkingStrategy;
}

@doc("""
  The chunking strategy used to chunk the file(s). If not set, will use the `auto` strategy.
  """)
@extension("x-oaiExpandable", true)
union ChunkingStrategyRequestParam {
  AutoChunkingStrategyRequestParam,
  StaticChunkingStrategyRequestParam,
}
