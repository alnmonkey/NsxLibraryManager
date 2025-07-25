﻿using NsxLibraryManager.Shared.Dto;

namespace NsxLibraryManager.Contracts;

public class FileDelta
{
    public required IEnumerable<LibraryTitleDto> FilesToAdd { get; init; }
    public required IEnumerable<LibraryTitleDto> FilesToRemove { get; init; }
    public required IEnumerable<LibraryTitleDto> FilesToUpdate { get; init; }
    
    public int TotalFiles { get; init; }

}