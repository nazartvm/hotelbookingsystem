using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBookingSystem.Data.Migrations
{
    public partial class modelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserTokens_AspNetUsers_UserId", table: "AspNetUserTokens");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserRoles_AspNetUsers_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserLogins_AspNetUsers_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserClaims_AspNetUsers_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropPrimaryKey(name: "PK_AspNetUsers", table: "AspNetUsers");

            migrationBuilder.DropForeignKey(name: "FK_AspNetUserRoles_AspNetRoles_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AspNetRoleClaims_AspNetRoles_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropPrimaryKey(name: "PK_AspNetRoles", table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(name: "PK_AspNetUserTokens", table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(name: "PK_AspNetUserRoles", table: "AspNetUserRoles");

            migrationBuilder.AddColumn<int>(name: "Idtmp", table: "AspNetUsers").Annotation("SqlServer:Identity", "1, 1"); ;
            migrationBuilder.DropColumn(name: "Id", table: "AspNetUsers");
            migrationBuilder.RenameColumn(name: "IdTmp", table: "AspNetUsers", "Id");

            migrationBuilder.AddColumn<int>(name: "Idtmp", table: "AspNetRoles").Annotation("SqlServer:Identity", "1, 1"); ;
            migrationBuilder.DropColumn(name: "Id", table: "AspNetRoles");
            migrationBuilder.RenameColumn(name: "IdTmp", table: "AspNetRoles", "Id");

            migrationBuilder.AlterColumn<int>(name: "UserId", table: "AspNetUserTokens", nullable: false, oldClrType: typeof(string), oldType: "nvarchar(450)");
            migrationBuilder.AlterColumn<int>(name: "RoleId", table: "AspNetUserRoles", nullable: false, oldClrType: typeof(string), oldType: "nvarchar(450)");
            migrationBuilder.AlterColumn<int>(name: "UserId", table: "AspNetUserRoles", nullable: false, oldClrType: typeof(string), oldType: "nvarchar(450)");
            migrationBuilder.AlterColumn<int>(name: "UserId", table: "AspNetUserLogins", nullable: false, oldClrType: typeof(string), oldType: "nvarchar(450)");
            migrationBuilder.AlterColumn<int>(name: "UserId", table: "AspNetUserClaims", nullable: false, oldClrType: typeof(string), oldType: "nvarchar(450)");
            migrationBuilder.AlterColumn<int>(name: "RoleId", table: "AspNetRoleClaims", nullable: false, oldClrType: typeof(string), oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(name: "PK_AspNetUserRoles", table: "AspNetUserRoles", columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(name: "PK_AspNetUserTokens", table: "AspNetUserTokens", columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(name: "PK_AspNetRoles", table: "AspNetRoles", column: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserRoles_AspNetRoles_RoleId", table: "AspNetUserRoles", column: "RoleId", principalTable: "AspNetRoles", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetRoleClaims_AspNetRoles_RoleId", table: "AspNetRoleClaims", column: "RoleId", principalTable: "AspNetRoles", principalColumn: "Id", onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddPrimaryKey(name: "PK_AspNetUsers", table: "AspNetUsers", column: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserTokens_AspNetUsers_UserId", table: "AspNetUserTokens", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserRoles_AspNetUsers_UserId", table: "AspNetUserRoles", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserLogins_AspNetUsers_UserId", table: "AspNetUserLogins", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserClaims_AspNetUsers_UserId", table: "AspNetUserClaims", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id", onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
