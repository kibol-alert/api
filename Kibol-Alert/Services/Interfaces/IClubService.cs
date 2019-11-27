﻿using Kibol_Alert.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IClubService
    {
        public Task<Response> GetClubs(int skip, int take);
        public Task<Response> GetClub(int id);
        public Task<Response> AddClub(ClubRelationRequest request);
        public Task<Response> DeleteClub(int id);
        public Task<Response> EditClub(int id, ClubRelationRequest request);
        public Task<Response> AddRelation(ClubRelationRequest request);
        public Task<Response> DeleteRelation(int id);
    }
}
