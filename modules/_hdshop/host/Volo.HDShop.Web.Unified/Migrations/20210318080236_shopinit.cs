using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volo.HDShop.Migrations
{
    public partial class shopinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HDShopDeliverCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopDeliverCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDShopGood",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBaseUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleStates_IsHot = table.Column<bool>(type: "bit", nullable: true),
                    SaleStates_IsNew = table.Column<bool>(type: "bit", nullable: true),
                    SaleStates_IsDiscount = table.Column<bool>(type: "bit", nullable: true),
                    SaleStates_IsRecommand = table.Column<bool>(type: "bit", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopGood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDShopGoodCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GoodDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopGoodCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDShopGoodCategory_HDShopGoodCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "HDShopGoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HDShopGoodProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    ParentGoodPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopGoodProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDShopGoodProperty_HDShopGoodProperty_ParentGoodPropertyId",
                        column: x => x.ParentGoodPropertyId,
                        principalTable: "HDShopGoodProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HDShopPayCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopPayCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDShopShopUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopShopUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDShopGoodSku",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    PriceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceProduct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumSales = table.Column<int>(type: "int", nullable: false),
                    NumSalesReal = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopGoodSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDShopGoodSku_HDShopGood_GoodId",
                        column: x => x.GoodId,
                        principalTable: "HDShopGood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodGoodCategory",
                columns: table => new
                {
                    GoodCategorysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodGoodCategory", x => new { x.GoodCategorysId, x.GoodsId });
                    table.ForeignKey(
                        name: "FK_GoodGoodCategory_HDShopGood_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "HDShopGood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodGoodCategory_HDShopGoodCategory_GoodCategorysId",
                        column: x => x.GoodCategorysId,
                        principalTable: "HDShopGoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodGoodProperty",
                columns: table => new
                {
                    GoodPropertiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodGoodProperty", x => new { x.GoodPropertiesId, x.GoodsId });
                    table.ForeignKey(
                        name: "FK_GoodGoodProperty_HDShopGood_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "HDShopGood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodGoodProperty_HDShopGoodProperty_GoodPropertiesId",
                        column: x => x.GoodPropertiesId,
                        principalTable: "HDShopGoodProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HDShopDeliverAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopDeliverAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDShopDeliverAddress_HDShopShopUser_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "HDShopShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDShopDeliverAddress_HDShopShopUser_DeleterId",
                        column: x => x.DeleterId,
                        principalTable: "HDShopShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDShopDeliverAddress_HDShopShopUser_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "HDShopShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HDShopOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    DeliverAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PayOrder_Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PayOrder_PayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PayOrder_CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliverOrder_Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DeliverOrder_DeliverCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliverOrder_CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDShopOrder_HDShopDeliverAddress_DeliverAddressId",
                        column: x => x.DeliverAddressId,
                        principalTable: "HDShopDeliverAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDShopOrder_HDShopDeliverCompany_DeliverOrder_DeliverCompanyId",
                        column: x => x.DeliverOrder_DeliverCompanyId,
                        principalTable: "HDShopDeliverCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDShopOrder_HDShopShopUser_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "HDShopShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDShopOrder_HDShopShopUser_DeleterId",
                        column: x => x.DeleterId,
                        principalTable: "HDShopShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDShopOrder_HDShopShopUser_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "HDShopShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HDShopOrderLine",
                columns: table => new
                {
                    GoodSkuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDShopOrderLine", x => new { x.OrderId, x.GoodSkuId });
                    table.ForeignKey(
                        name: "FK_HDShopOrderLine_HDShopOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "HDShopOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodGoodCategory_GoodsId",
                table: "GoodGoodCategory",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodGoodProperty_GoodsId",
                table: "GoodGoodProperty",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopDeliverAddress_CreatorId",
                table: "HDShopDeliverAddress",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopDeliverAddress_DeleterId",
                table: "HDShopDeliverAddress",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopDeliverAddress_LastModifierId",
                table: "HDShopDeliverAddress",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopGoodCategory_ParentCategoryId",
                table: "HDShopGoodCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopGoodProperty_ParentGoodPropertyId",
                table: "HDShopGoodProperty",
                column: "ParentGoodPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopGoodSku_GoodId",
                table: "HDShopGoodSku",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopOrder_CreatorId",
                table: "HDShopOrder",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopOrder_DeleterId",
                table: "HDShopOrder",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopOrder_DeliverAddressId",
                table: "HDShopOrder",
                column: "DeliverAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopOrder_DeliverOrder_DeliverCompanyId",
                table: "HDShopOrder",
                column: "DeliverOrder_DeliverCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HDShopOrder_LastModifierId",
                table: "HDShopOrder",
                column: "LastModifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodGoodCategory");

            migrationBuilder.DropTable(
                name: "GoodGoodProperty");

            migrationBuilder.DropTable(
                name: "HDShopGoodSku");

            migrationBuilder.DropTable(
                name: "HDShopOrderLine");

            migrationBuilder.DropTable(
                name: "HDShopPayCompany");

            migrationBuilder.DropTable(
                name: "HDShopGoodCategory");

            migrationBuilder.DropTable(
                name: "HDShopGoodProperty");

            migrationBuilder.DropTable(
                name: "HDShopGood");

            migrationBuilder.DropTable(
                name: "HDShopOrder");

            migrationBuilder.DropTable(
                name: "HDShopDeliverAddress");

            migrationBuilder.DropTable(
                name: "HDShopDeliverCompany");

            migrationBuilder.DropTable(
                name: "HDShopShopUser");
        }
    }
}
