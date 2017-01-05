using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCore.IdentityDemo.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
