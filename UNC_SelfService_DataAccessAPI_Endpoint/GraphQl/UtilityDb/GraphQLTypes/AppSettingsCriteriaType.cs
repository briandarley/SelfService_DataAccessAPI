using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.GraphQl.UtilityDb.GraphQLTypes
{
    public class AppSettingsCriteriaType : InputObjectType<AppSettingsCriteria>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AppSettingsCriteria> descriptor)
        {
            descriptor.Field(t => t.Id).Type<IdType>().Description("The ID of the AppSetting.");
            descriptor.Field(t => t.Name).Type<StringType>().Description("The name of the AppSetting.");
            descriptor.Field(t => t.AppDomain).Type<StringType>().Description("The domain of the App.");
            descriptor.Field(t => t.Filter).Type<StringType>().Description("A filter string for searching AppSettings.");
        }
    }

}
