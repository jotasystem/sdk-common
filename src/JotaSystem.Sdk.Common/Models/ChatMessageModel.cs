using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Common.Models
{
    public class ChatMessageModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ChatRoleEnum Role { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}