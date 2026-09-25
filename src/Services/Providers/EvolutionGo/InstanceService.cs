using Domain.Dtos;
using Domain.Records;
using Infra.Providers.EvolutionGo;

namespace Services.Providers.EvolutionGo;


public class InstanceService
{
    EvolutionGoIntegration _evolutionGoIntegration;
    
    public InstanceService(EvolutionGoIntegration evolutionGoIntegration)
    {
        _evolutionGoIntegration = evolutionGoIntegration;
    }
    public Task<Result<string>> CreateInstance(string evoGoToken, CreateInstanceDto dto)
    {

        var nameInstance = $"{dto.Name}_{Guid.NewGuid()}";
        
        var req = new CreateInstanceDto(
            Name : nameInstance,
            Token : nameInstance,
            AdvanceSettings: dto.AdvanceSettings
            );
        
        return _evolutionGoIntegration.CreateInstance(evoGoToken, req);
    } 
    
    
    public Task<Result<string>> ConnectQr(string evoGoToken)
    {
        
        return _evolutionGoIntegration.ConnectQr(evoGoToken);
    } 
    
    public Task<Result<string>> GetStatus(string evoGoToken)
    {
        
        return _evolutionGoIntegration.GetStatus(evoGoToken);
    } 
    
    public Task<Result<string>> Delete(string evoGoToken, string instanceId)
    {
        
        return _evolutionGoIntegration.Delete(evoGoToken, instanceId);
    } 
    
    public Task<Result<string>> Disconnect(string evoGoToken)
    {
        
        return _evolutionGoIntegration.Disconnect(evoGoToken);
    } 
    
    
    public Task<Result<string>> GetAll(string evoGoToken)
    {
        
        return _evolutionGoIntegration.GetAll(evoGoToken);
    } 
    
    public Task<Result<string>> Get(string evoGoToken, string instanceId)
    {
        
        return _evolutionGoIntegration.Get(evoGoToken, instanceId);
    } 
}
