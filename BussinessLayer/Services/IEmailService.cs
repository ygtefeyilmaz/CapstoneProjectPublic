﻿namespace DataAccessLayer.Services
{
    public interface IEmailService
    {

        Task SendResetPasswordEmail(string resetPasswordEmailLink, string ToEmail);
    }
}
