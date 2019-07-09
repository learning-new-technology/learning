using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Models.Dto
{
    public class JsonModel
    {
        [Serializable]
        [DataContract]
        public class ToList<T>
        {
            [DataMember(Order = 1, Name = "status", IsRequired = true)]
            public bool IsSuccess { get; set; } = true;

            [DataMember(Order = 3, Name = "data", IsRequired = false, EmitDefaultValue = false)]
            public List<T> Result { get; set; } = new List<T>();

            [DataMember(Order = 2, Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public string Message { get; set; } = "";
        }

        [Serializable]
        [DataContract]
        public class ToObject<T>
        {
            [DataMember(Order = 1, Name = "status", IsRequired = true)]
            public bool IsSuccess { get; set; } = true;

            [DataMember(Order = 3, Name = "data", IsRequired = false, EmitDefaultValue = false)]
            public T Result { get; set; }

            [DataMember(Order = 2, Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public string Message { get; set; } = "";
        }
    }
}
