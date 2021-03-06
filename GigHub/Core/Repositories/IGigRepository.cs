﻿using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        IEnumerable<Gig> GetAllUpcomingGigs();
        Gig GetGigById(int id);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        Gig GetGigWithGenreAndArtist(int id);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        Gig GetGigFromArtist(int id, string userId);
    }
}