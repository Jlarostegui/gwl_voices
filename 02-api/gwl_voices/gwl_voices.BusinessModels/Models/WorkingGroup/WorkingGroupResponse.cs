﻿namespace gwl_voices.BusinessModels.Models.WorkingGroup
{
    public class WorkingGroupResponse : BaseResponse
    {
        public String? WorkingGroupName { get; set; }

        public static implicit operator List<object>(WorkingGroupResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
