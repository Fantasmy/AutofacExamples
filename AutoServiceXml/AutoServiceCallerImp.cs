using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    public class AutoServiceCallerImp : AutoServiceCaller
    {

        private AutoService bmwAutoService;

        private AutoService hondaAutoService;

        private AutoService fordAutoService;

        public AutoServiceCallerImp(AutoService bmwAutoService, AutoService hondaAutoService, AutoService fordAutoService)
        {
            this.bmwAutoService = bmwAutoService;
            this.hondaAutoService = hondaAutoService;
            this.fordAutoService = fordAutoService;
        }

        public void callAutoService()
        {
            // get bmw's auto service
            bmwAutoService.getService();

            // get ford's auto service
            fordAutoService.getService();

            // get honda's auto service
            hondaAutoService.getService();
        }

    }
}
