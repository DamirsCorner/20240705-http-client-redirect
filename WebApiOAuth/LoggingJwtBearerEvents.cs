using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiOAuth;

public class LoggingJwtBearerEvents(ILogger<LoggingJwtBearerEvents> logger) : JwtBearerEvents
{
    public override Task MessageReceived(MessageReceivedContext context)
    {
        logger.LogInformation(
            "MessageReceived: {Scheme}://{Host}",
            context.Request.Scheme,
            context.Request.Host
        );
        return base.MessageReceived(context);
    }

    public override Task TokenValidated(TokenValidatedContext context)
    {
        logger.LogInformation(
            "TokenValidated: {Scheme}://{Host}",
            context.Request.Scheme,
            context.Request.Host
        );
        return base.TokenValidated(context);
    }

    public override Task Challenge(JwtBearerChallengeContext context)
    {
        logger.LogInformation(
            "Challenge, {Scheme}://{Host}",
            context.Request.Scheme,
            context.Request.Host
        );
        return base.Challenge(context);
    }
}
