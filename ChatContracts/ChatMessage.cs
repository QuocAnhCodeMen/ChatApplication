using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChatContracts;

public class ChatMessage
{
    public string? FromUserId { set; get; } = string.Empty;
    public string? ToUserId { set; get; } = string.Empty;

    public string? Message { set; get; } = string.Empty;

    public bool Unread { set; get; } = true;
}
