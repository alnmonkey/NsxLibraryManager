﻿using Microsoft.AspNetCore.Components;
using NsxLibraryManager.Enums;
using NsxLibraryManager.Models;
using NsxLibraryManager.Services;
using Radzen;

namespace NsxLibraryManager.Pages;

public partial class GameLibrary
{
    
    [Inject]
    protected IDataService DataService { get; set; }
    
    string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
    int pageSize = 10;
    int count;
    public bool isLoading;
    
    IEnumerable<LibraryTitle> games;
    
    
    async Task PageChanged(PagerEventArgs args)
    {
        var loadDataArgs = new LoadDataArgs { 
                Top = args.Top,
                Skip = args.Skip
        };
        await LoadData(loadDataArgs);
    }
    
    async Task LoadData(LoadDataArgs args)
    {
        isLoading = true;

        var libraryTitles = await DataService.GetLibraryTitlesQueryableAsync();
        var baseGames = libraryTitles.Where(o => o.Type == TitleLibraryType.Base);
        count = baseGames.Count();
        games = baseGames
                .Take(args.Top ?? pageSize)
                .Skip(args.Skip ?? 0)
                .ToList();

        isLoading = false;
    }
}