using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiUI.ViewComponents
{
    public class EmptyProject : ViewComponent
    {

        private readonly IEmptyProjectService _emptyProjectService;

       
       

        public EmptyProject(IEmptyProjectService emptyProjectService )
        {
            _emptyProjectService = emptyProjectService;
           
        }

        public IViewComponentResult Invoke()
        {

            var value = _emptyProjectService.GetContactList();
            return View(value);
        }


    }
}
