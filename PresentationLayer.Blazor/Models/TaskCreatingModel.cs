using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Globalization;

namespace PresentationLayer.Blazor.Models
{
    public class TaskCreatingModel : ComponentBase
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        protected TaskCreatingViewModel NewTaskData { get; set; } = null!;

        protected bool IsCreateButtonDisabled { get; set; } = false;

        protected PatternMask LeadTimeMask = new("0 days 00 hours 00 minutes")
        {
            MaskChars = new[] {
                MaskChar.Digit('0')
            },
            CleanDelimiters = true,
            Placeholder = '_'
        };

        //protected Converter<TimeSpan> LeadTimeConverter = new()
        //{
        //    SetFunc = value => {
        //        var v = value.ToString(@"d' days 'hh' hours 'mm' minutes'");
        //        return v;
        //    },
        //    GetFunc = text =>
        //    {
        //        TimeSpan timespan;
        //        TimeSpan.TryParseExact(text, @"d' days 'hh' hours 'mm' minutes'",
        //              CultureInfo.CurrentCulture, out timespan);

        //        return timespan;
        //    }
        //};

        protected override async Task OnInitializedAsync()
        {
            MudDialog.Title = "New task";
            NewTaskData = new();
            await base.OnInitializedAsync();
        }

        protected async Task OnCreateClickedAsync()
        {

        }

        protected void Cancel() => MudDialog.Cancel();
    }
}
