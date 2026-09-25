using Domain.Dtos.MetaApi;
using Domain.Records;
using Infra.Providers.Meta;

namespace Services.Providers.MetaApi;

public class AccountService(Account account)
{
    public Task<Result<string>> RegisterPhone(string metaToken, RegisterPhoneNumberDto data, MetaOptions options)
    {
        return account.RegisterPhone(metaToken, data, options);
    }

    public Task<Result<string>> DeregisterPhone(string metaToken, MetaOptions options)
    {
        return account.DeregisterPhone(metaToken, options);
    }

    public Task<Result<string>> SubscribeWABA(string metaToken, string wabaId, string version)
    {
        return account.SubscribeWABA(metaToken, wabaId, version);
    }

    public Task<Result<string>> GetOwnedWABAs(string metaToken, string businessId, string version)
    {
        return account.GetOwnedWABAs(metaToken, businessId, version);
    }

    public Task<Result<string>> GetSharedWABAs(string metaToken, string businessId, string version)
    {
        return account.GetSharedWABAs(metaToken, businessId, version);
    }

    public Task<Result<string>> GetPhonesByWABAId(string metaToken, string wabaId, string version)
    {
        return account.GetPhonesByWABAId(metaToken, wabaId, version);
    }

    public Task<Result<string>> RequestVerificationCode(string metaToken, RequestVerificationCodeDto data, MetaOptions options)
    {
        return account.RequestVerificationCode(metaToken, data, options);
    }

    public Task<Result<string>> VerifyCode(string metaToken, VerifyCodeDto data, MetaOptions options)
    {
        return account.VerifyCode(metaToken, data, options);
    }

    public Task<Result<string>> SetTwoStepVerification(string metaToken, SetTwoTepVerificationCodeDto data, MetaOptions options)
    {
        return account.SetTwoStepVerification(metaToken, data, options);
    }
}
