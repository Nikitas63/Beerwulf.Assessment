using System.Collections.Generic;

namespace Review.Contracts.Result
{
    /// <summary>
    /// Represents operation status and returned payload
    /// </summary>
    /// <typeparam name="T">Type of payload</typeparam>
    public class OperationResult<T>
    {
        private OperationResult()
        { }
        
        /// <summary>
        /// Indicates status of operation
        /// </summary>
        public OperationStatus Status { get; protected set; }

        public IEnumerable<ErrorModel> Errors { get; protected set; }

        public T Payload { get; private set; }

        #region Create

        /// <summary>
        /// Create operation result with payload
        /// </summary>
        /// <returns></returns>
        public static OperationResult<T> Create(
            T payload,
            OperationStatus status = OperationStatus.Success,
            IEnumerable<ErrorModel> validationResults = null,
            IDictionary<string, string> warnings = null) =>
            new OperationResult<T>()
            {
                Payload = payload,
                Status = status,
                Errors = validationResults
            };
        
        #endregion
        
        #region Invalid results
        
        /// <summary>
        /// Creates an invalid result with a single validation error
        /// </summary>
        /// <param name="fieldName">The name of invalid property</param>
        /// <param name="message">Validation message</param>
        public static OperationResult<T> CreateInvalid(string fieldName, string message) =>
            Create(
                payload: default,
                OperationStatus.InvalidInput,
                 new List<ErrorModel>
                 {
                     new ErrorModel
                     {
                         FieldName = fieldName,
                         Message = message
                     }
                 });

        #endregion

        #region Status fields

        public static OperationResult<T> Conflict => new OperationResult<T> { Status = OperationStatus.Conflict };

        public static OperationResult<T> NotFound => new OperationResult<T> { Status = OperationStatus.NotFound };

        #endregion
    }
}