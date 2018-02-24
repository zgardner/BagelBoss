using System;
using System.Web.Http;

using BagelBoss.Contracts;
using BagelBoss.Service;

namespace BagelBoss.API.Controllers
{
    public class BagelController : ApiController
    {
        private readonly IBagelService bagelService;

        public BagelController(IBagelService bagelService)
        {
            this.bagelService = bagelService;
        }

        [HttpPost]
        public Bagel Create(Boolean toasted)
        {
            return bagelService.CreateBagel(toasted);
        }
    }
}
