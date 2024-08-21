﻿using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface IReceivedEmailRepository
    {
        IEnumerable<ReceivedEmail> GetAll(int page);
    }
}