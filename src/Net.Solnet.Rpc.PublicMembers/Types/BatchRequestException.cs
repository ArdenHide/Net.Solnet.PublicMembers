using Net.Solnet.Rpc.PublicMembers.Core.Http;
using Net.Solnet.Rpc.PublicMembers.Messages;

namespace Net.Solnet.Rpc.PublicMembers.Types
{
    /// <summary>
    /// Encapsulates the batch request failure that is relayed to all callbacks
    /// </summary>
    public class BatchRequestException : ApplicationException
    {
        /// <summary>
        /// The RPC result that failed
        /// </summary>
        public RequestResult<JsonRpcBatchResponse> RpcResult;

        /// <summary>
        /// Contructs a BatchRequestException based on the JsonRpcBatchResponse result.
        /// </summary>
        /// <param name="result"></param>
        public BatchRequestException(RequestResult<JsonRpcBatchResponse> result) : base($"Batch request failure - {result.Reason}")
        {
            RpcResult = result;
        }

    }
}
