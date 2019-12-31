using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TourGuideBD.Data.Migrations
{
    public partial class version_one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "RegClientName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentText = table.Column<string>(maxLength: 500, nullable: false),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsSeen = table.Column<bool>(nullable: false),
                    SenderName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionName = table.Column<string>(maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                });

            migrationBuilder.CreateTable(
                name: "PlaceType",
                columns: table => new
                {
                    PlaceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    PlaceTypeName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.PlaceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Distric",
                columns: table => new
                {
                    DistricId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistricName = table.Column<string>(maxLength: 50, nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distric", x => x.DistricId);
                    table.ForeignKey(
                        name: "FK_Distric_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upazila",
                columns: table => new
                {
                    UpazilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistricId = table.Column<int>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    UpazilaName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazila", x => x.UpazilaId);
                    table.ForeignKey(
                        name: "FK_Upazila_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddNewPlaceByClient",
                columns: table => new
                {
                    PlaceByClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactInfo = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    DistricId = table.Column<int>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    EntryFee = table.Column<string>(maxLength: 500, nullable: false),
                    HowToGo = table.Column<string>(maxLength: 1000, nullable: false),
                    Image = table.Column<byte[]>(nullable: false),
                    IsSeen = table.Column<bool>(nullable: false),
                    Phone = table.Column<int>(maxLength: 20, nullable: false),
                    PlaceName = table.Column<string>(maxLength: 200, nullable: false),
                    PlaceTypeId = table.Column<int>(nullable: false),
                    SenderName = table.Column<string>(nullable: false),
                    TouristEntryTime = table.Column<string>(maxLength: 500, nullable: false),
                    UpazilaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddNewPlaceByClient", x => x.PlaceByClientId);
                    table.ForeignKey(
                        name: "FK_AddNewPlaceByClient_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddNewPlaceByClient_PlaceType_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "PlaceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitingPlace",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactInfo = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    DistricId = table.Column<int>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    EntryFee = table.Column<string>(maxLength: 500, nullable: false),
                    HowToGo = table.Column<string>(maxLength: 1000, nullable: false),
                    Image = table.Column<byte[]>(nullable: false),
                    PlaceName = table.Column<string>(maxLength: 200, nullable: false),
                    PlaceTypeId = table.Column<int>(nullable: false),
                    TouristEntryTime = table.Column<string>(maxLength: 500, nullable: false),
                    UpazilaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitingPlace", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_VisitingPlace_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitingPlace_PlaceType_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "PlaceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AddNewPlaceByClient_DivisionId",
                table: "AddNewPlaceByClient",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AddNewPlaceByClient_PlaceTypeId",
                table: "AddNewPlaceByClient",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Distric_DivisionId",
                table: "Distric",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazila_DivisionId",
                table: "Upazila",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitingPlace_DivisionId",
                table: "VisitingPlace",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitingPlace_PlaceTypeId",
                table: "VisitingPlace",
                column: "PlaceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AddNewPlaceByClient");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Distric");

            migrationBuilder.DropTable(
                name: "Upazila");

            migrationBuilder.DropTable(
                name: "VisitingPlace");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "PlaceType");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "RegClientName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegDate",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
