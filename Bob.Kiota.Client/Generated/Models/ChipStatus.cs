using System.Runtime.Serialization;
using System;
namespace Bob.Kiota.Client.Models {
    public enum ChipStatus {
        [EnumMember(Value = "NotChipped")]
        NotChipped,
        [EnumMember(Value = "Chipped")]
        Chipped,
    }
}
