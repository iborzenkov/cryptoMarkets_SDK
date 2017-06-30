using System.Runtime.Serialization;

namespace Bittrex.DataTypes
{
    [DataContract]
    public abstract class BaseDataType
    {
        /// <summary>
        /// Success
        /// </summary>
        [DataMember(Name = "success", EmitDefaultValue = false)]
        public bool Success { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }
    }
}