using System;

namespace GameServer.Core;

public static class IdUtils
{
    public static string ToId(this string str)
    {
        return str.Replace(" ", "").ToLower();
    }
}
