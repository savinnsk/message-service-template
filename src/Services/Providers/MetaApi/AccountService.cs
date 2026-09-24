using Domain.Dtos.MetaApi;
using Domain.Records;
using Infra.Providers.Meta;

namespace Services.Providers.MetaApi;

public class AccountService(Account account)
{
    public Task<Result<string>> RegisterPhone(RegisterPhoneNumberDto data, MetaOptions options)
    {
        return account.RegisterPhone(data, options);
    }

    public Task<Result<string>> DeregisterPhone(MetaOptions options)
    {
        return account.DeregisterPhone(options);
    }

    public Task<Result<string>> SubscribeWABA(string wabaId, MetaOptions options)
    {
        return account.SubscribeWABA(wabaId, options);
    }

    public Task<Result<string>> GetOwnedWABAs(string businessId, MetaOptions options)
    {
        return account.GetOwnedWABAs(businessId, options);
    }

    public Task<Result<string>> GetSharedWABAs(string businessId, MetaOptions options)
    {
        return account.GetSharedWABAs(businessId, options);
    }

    public Task<Result<string>> GetPhonesByWABAId(string wabaId, MetaOptions options)
    {
        return account.GetPhonesByWABAId(wabaId, options);
    }

    public Task<Result<string>> RequestVerificationCode(RequestVerificationCodeDto data, MetaOptions options)
    {
        return account.RequestVerificationCode(data, options);
    }

    public Task<Result<string>> VerifyCode(VerifyCodeDto data, MetaOptions options)
    {
        return account.VerifyCode(data, options);
    }

    public Task<Result<string>> SetTwoStepVerification(SetTwoTepVerificationCodeDto data, MetaOptions options)
    {
        return account.SetTwoStepVerification(data, options);
    }
}
