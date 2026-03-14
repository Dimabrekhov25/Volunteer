namespace Volunteer.Domain.Constants;

public class ErrorCodes
{
    public const string NotFound = "NOT_FOUND";
    public const string BadRequest = "BAD_REQUEST";
    public const string Conflict = "CONFLICT";
    public const string Unauthorized = "UNAUTHORIZED";
    public const string Forbidden = "FORBIDDEN";
    public const string InternalError = "INTERNAL_ERROR";
    public const string ValidationError = "VALIDATION_ERROR";
    public static class User
    {
        public const string EmailInUse = "EMAIL_IN_USE";
        public const string PhoneInUse = "PHONE_IN_USE";
        public const string AlreadyVerified = "ALREADY_VERIFIED";
        public const string InvalidToken = "INVALID_TOKEN";
        public const string AccountLocked = "ACCOUNT_LOCKED";
    }
}