﻿using SlipeServer.Server;
using SlipeServer.Server.Elements;
using SlipeServer.Server.Resources;

namespace SlipeServer.Resource.NoClip;

internal class NoClipResource : Server.Resources.Resource
{
    private readonly NoClipOptions _options;

    internal Dictionary<string, byte[]> AdditionalFiles { get; } = new Dictionary<string, byte[]>()
    {
        ["noclip.lua"] = ResourceFiles.NoClipLua,
    };

    internal NoClipOptions Options => _options;

    internal NoClipResource(MtaServer server, NoClipOptions options)
        : base(server, server.GetRequiredService<RootElement>(), "NoClip")
    {
        foreach (var (path, content) in AdditionalFiles)
            Files.Add(ResourceFileFactory.FromBytes(content, path));
        _options = options;
    }

}