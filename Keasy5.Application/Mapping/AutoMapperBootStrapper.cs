using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ByteartRetail.DataObjects;
using Keasy5.Domain.Model;

namespace Keasy5.Application.Mapping
{
    public class AutoMapperBootstrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<AddressDataObject, Address>();
            Mapper.CreateMap<UserDataObject, User>()
                .ForMember(uMember => uMember.ContactAddress, mceUDO =>mceUDO.ResolveUsing<AddressResolver>().FromMember(fm => fm.ContactAddress))
                .ForMember(uMember => uMember.DeliveryAddress, mceUDO =>mceUDO.ResolveUsing<AddressResolver>().FromMember(fm => fm.DeliveryAddress));
            Mapper.CreateMap<User, UserDataObject>()
                .ForMember(udoMember => udoMember.ContactAddress, mceU => mceU.ResolveUsing<InversedAddressResolver>().FromMember(fm => fm.ContactAddress))
                .ForMember(udoMember => udoMember.DeliveryAddress, mceU =>mceU.ResolveUsing<InversedAddressResolver>().FromMember(fm => fm.DeliveryAddress));
            Mapper.CreateMap<RoleDataObject, Role>();
            Mapper.CreateMap<Role, RoleDataObject>();
            Mapper.CreateMap<Address, AddressDataObject>();
            Mapper.CreateMap<Product, ProductDataObject>();
            Mapper.CreateMap<ProductDataObject, Product>();
            Mapper.CreateMap<Category, CategoryDataObject>();
            Mapper.CreateMap<CategoryDataObject, Category>();
            Mapper.CreateMap<Categorization, CategorizationDataObject>();
            Mapper.CreateMap<CategorizationDataObject, Categorization>();
            Mapper.CreateMap<SalesLine, SalesLineDataObject>();
            Mapper.CreateMap<SalesOrder, SalesOrderDataObject>()
                .ForMember(sodoMember => sodoMember.Subtotal, mceSo => mceSo.ResolveUsing(so => so.SalesLines.Sum(sl => sl.LineAmount)))
                .ForMember(sodoMember => sodoMember.CustomerContact, mceSo =>mceSo.ResolveUsing(so =>so.User.Contact))
                .ForMember(sodoMember => sodoMember.CustomerPhone, mceSo => mceSo.ResolveUsing(so =>so.User.PhoneNumber))
                .ForMember(sodoMember => sodoMember.CustomerEmail, mceSo => mceSo.ResolveUsing(so => so.User.Email))
                .ForMember(sodoMember => sodoMember.CustomerID, mceSo => mceSo.ResolveUsing(so => so.User.ID))
                .ForMember(sodoMember => sodoMember.CustomerName, mceSo => mceSo.ResolveUsing(so => so.User.UserName))
                .ForMember(sodoMember => sodoMember.CustomerAddressCountry, mceSo => mceSo.ResolveUsing(so => so.User.DeliveryAddress.Country))
                .ForMember(sodoMember => sodoMember.CustomerAddressState, mceSo => mceSo.ResolveUsing(so => so.User.DeliveryAddress.State))
                .ForMember(sodoMember => sodoMember.CustomerAddressCity, mceSo => mceSo.ResolveUsing(so => so.User.DeliveryAddress.City))
                .ForMember(sodoMember => sodoMember.CustomerAddressStreet, mceSo => mceSo.ResolveUsing(so => so.User.DeliveryAddress.Street))
                .ForMember(sodoMember => sodoMember.CustomerAddressZip, mceSo => mceSo.ResolveUsing(so => so.User.DeliveryAddress.Zip))
                .ForMember(sodoMember => sodoMember.Status, mceSo => mceSo.ResolveUsing(so =>
                                                                                            {
                                                                                                switch (so.Status)
                                                                                                {
                                                                                                    case SalesOrderStatus.Created:
                                                                                                        return SalesOrderStatusDataObject.Created;
                                                                                                    case SalesOrderStatus.Delivered:
                                                                                                        return SalesOrderStatusDataObject.Delivered;
                                                                                                    case SalesOrderStatus.Dispatched:
                                                                                                        return SalesOrderStatusDataObject.Dispatched;
                                                                                                    case SalesOrderStatus.Paid:
                                                                                                        return SalesOrderStatusDataObject.Paid;
                                                                                                    case SalesOrderStatus.Picked:
                                                                                                        return SalesOrderStatusDataObject.Picked;
                                                                                                    default:
                                                                                                        throw new InvalidOperationException();
                                                                                                }
                                                                                            }));
            Mapper.CreateMap<SalesLineDataObject, SalesLine>();
            Mapper.CreateMap<SalesOrderDataObject, SalesOrder>();
            Mapper.CreateMap<ShoppingCart, ShoppingCartDataObject>();
            Mapper.CreateMap<ShoppingCartDataObject, ShoppingCart>();
            Mapper.CreateMap<ShoppingCartItem, ShoppingCartItemDataObject>();
            Mapper.CreateMap<ShoppingCartItemDataObject, ShoppingCartItem>();
        }
    }
}
