using BookStore.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Core.ViewModels
{
    public class RoleManagementVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
