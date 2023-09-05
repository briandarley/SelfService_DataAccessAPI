using UNC.Services.Responses;

namespace UNC_SelfService_DataAccessAPI_Endpoint.GraphQl
{
    public class ServiceResultType<T, TType> : ObjectType<ServiceResult<T>>
        where TType : ObjectType<T>
    {
        protected override void Configure(IObjectTypeDescriptor<ServiceResult<T>> descriptor)
        {
            descriptor.Field(f => f.Data).Type<TType>();
            descriptor.Field(f => f.Success).Type<NonNullType<BooleanType>>();
            descriptor.Field(f => f.Errors).Type<ListType<StringType>>();
        }
    }
}
