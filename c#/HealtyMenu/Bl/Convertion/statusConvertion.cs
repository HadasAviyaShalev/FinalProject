using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class statusConvertion
    {
        //convert one statusDto to status
        public static status convert(statusDto statuses)
        {
            status NewStatus = new status();
            NewStatus.id = statuses.id;
            NewStatus.age = statuses.age;
            NewStatus.description = statuses.description;

            return NewStatus;

        }

        //convert one status to statusDto
        public static statusDto convert(status Status)
        {
            statusDto NewStatusDto = new statusDto();
            NewStatusDto.id = Status.id;
            NewStatusDto.age = Status.age;
            NewStatusDto.description = Status.description;
            return NewStatusDto;

        }

        //convert list of status to statusDto
        public static List<statusDto> convert(List<status> Status)
        {
            List<statusDto> NewStatus = new List<statusDto>();
            Status.ForEach(x => {
                NewStatus.Add(convert(x));
            });
            return NewStatus;

        }
        //convert list of statusDto to status
        public static List<status> convert(List<statusDto> Status)
        {
            List<status> NewStatus = new List<status>();
            Status.ForEach(x => {
                NewStatus.Add(convert(x));
            });
            return NewStatus;

        }
    }
}
