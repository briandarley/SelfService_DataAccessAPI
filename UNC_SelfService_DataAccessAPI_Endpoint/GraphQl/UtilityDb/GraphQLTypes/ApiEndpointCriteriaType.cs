using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.GraphQl.UtilityDb.GraphQLTypes
{
    public class ApiEndpointCriteriaType : InputObjectType<ApiEndpointCriteria>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ApiEndpointCriteria> descriptor)
        {
            descriptor.Description("Criteria for filtering API endpoints.");

            // Assuming 'Id' can be optional in the filter
            descriptor.Field(t => t.Id)
                .Description("The ID of the API endpoint.")
                .Type<NonNullType<IntType>>()
                .DefaultValue(0); // default value

            // Name can be optional in the filter
            descriptor.Field(t => t.Name)
                .Description("The name of the API endpoint.")
                .Type<StringType>();

            // Uri can be optional in the filter
            descriptor.Field(t => t.Uri)
                .Description("The URI of the API endpoint.")
                .Type<StringType>();

            // Environment can be optional in the filter
            descriptor.Field(t => t.Environment)
                .Description("The environment of the API endpoint (e.g., 'production').")
                .Type<StringType>();
        }
    }
}
