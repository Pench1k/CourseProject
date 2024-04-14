using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ElectronicMagazineDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facultyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFaculty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    End = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfTheWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Facultyes_FacultyesId",
                        column: x => x.FacultyesId,
                        principalTable: "Facultyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<int>(type: "int", nullable: false),
                    NumberGroup = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    DisciplinesId = table.Column<int>(type: "int", nullable: false),
                    TypeSchedule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupsSchedules",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    SchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsSchedules", x => new { x.GroupsId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_GroupsSchedules_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsSchedules_Schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlotsSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotsId = table.Column<int>(type: "int", nullable: false),
                    SchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotsSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlotsSchedules_Schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlotsSchedules_Slots_SlotsId",
                        column: x => x.SlotsId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotScheduleId = table.Column<int>(type: "int", nullable: false),
                    TypePair = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pairs_SlotsSchedules_SlotScheduleId",
                        column: x => x.SlotScheduleId,
                        principalTable: "SlotsSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarksCount = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PairsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Pairs_PairsId",
                        column: x => x.PairsId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aa603b2-ce9f-4c84-9dfe-cd6b56a74c30", "1c47088f-552a-47fc-a1c3-8bb12930be3e", "Студент", null },
                    { "4f978b96-c136-48d7-a2ae-c97238ab0c8d", "192354b1-0a99-485c-9b10-44fa072140ab", "Преподаватель", null },
                    { "b5f14003-6e13-43c0-ac8d-16ee111f40ea", "e0306b46-48c9-4e12-bcbf-4eb4387fb060", "Декан", null },
                    { "e0621b50-4243-4206-93a4-b35d42fea37a", "5f44a1fe-cd84-442e-9f7e-6dbd41131959", "ЗамКафедры", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MiddleName", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "577b9340-1a02-4316-a983-42d70127751c", 0, "0254e60f-f83a-4457-a7f4-9d570888f77b", null, false, false, null, "Иванович", "Иван", null, null, null, null, false, "bd48a304-ec6e-4959-859b-a8c0cbb592a0", "Иванов", false, null },
                    { "60d70ac4-f7ea-44c3-ba80-89fb25039b33", 0, "c1b0d9f9-efa0-4753-86c2-837a44dba163", null, false, false, null, "Егорович", "Егор", null, null, null, null, false, "e84e34ac-e801-483e-8a60-3bb929798223", "Егоров", false, null },
                    { "8ed45042-5ce6-445b-a844-cf7a03eef945", 0, "66f703ae-5b8f-429a-8d8f-761ff79059f8", null, false, false, null, "Владиславович", "Влад", null, null, null, null, false, "5f239dcb-14fe-494e-a310-5ddcabac3649", "Владислов", false, null },
                    { "a23b98d9-288f-424a-b307-3fc787a0005b", 0, "44b2c6af-f3aa-496b-b0e8-7a891c8f4bfe", null, false, false, null, "Владиславович", "Влад", null, null, null, null, false, "76fe4a97-4cb4-4a9c-bb28-f95e60dd7d26", "Владислов", false, null },
                    { "d21d4f10-82b7-409b-b447-15478ed6c6f2", 0, "442b6721-a3e7-42ab-94bb-a3ba630c76d2", null, false, false, null, "Иванович", "Иван", null, null, null, null, false, "d9b367fd-74dd-4167-a96b-5c070032f230", "Иванов", false, null },
                    { "fc9a3784-05a1-4e14-8b00-2a0692d7a8ec", 0, "e30bad53-5e1e-465a-8f41-8c907c9b2c05", null, false, false, null, "Егорович", "Егор", null, null, null, null, false, "6485ec91-f55d-41fe-9f80-b36a67719285", "Егоров", false, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "DisciplineName" },
                values: new object[,]
                {
                    { 1, "КИС" },
                    { 2, "РПИ" },
                    { 3, "ОСиСП" },
                    { 4, "ОУИС" },
                    { 5, "ПМП" },
                    { 6, "БЖЧ" },
                    { 7, "ФизКульт" },
                    { 8, "Экономика" },
                    { 9, "ММСС" }
                });

            migrationBuilder.InsertData(
                table: "Facultyes",
                columns: new[] { "Id", "NameFaculty" },
                values: new object[] { 1, "ФАИС" });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "DayOfTheWeek", "End", "Start" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 8, 20, 0, 0) },
                    { 2, 1, new TimeSpan(0, 11, 25, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 3, 1, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 35, 0, 0) },
                    { 4, 1, new TimeSpan(0, 14, 55, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 5, 1, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 15, 5, 0, 0) },
                    { 6, 2, new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 8, 20, 0, 0) },
                    { 7, 2, new TimeSpan(0, 11, 25, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 8, 2, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 35, 0, 0) },
                    { 9, 2, new TimeSpan(0, 14, 55, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 10, 2, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 15, 5, 0, 0) },
                    { 11, 3, new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 8, 20, 0, 0) },
                    { 12, 3, new TimeSpan(0, 11, 25, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 13, 3, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 35, 0, 0) },
                    { 14, 3, new TimeSpan(0, 14, 55, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 15, 3, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 15, 5, 0, 0) },
                    { 16, 4, new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 8, 20, 0, 0) },
                    { 17, 4, new TimeSpan(0, 11, 25, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 18, 4, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 35, 0, 0) },
                    { 19, 4, new TimeSpan(0, 14, 55, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 20, 4, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 15, 5, 0, 0) },
                    { 21, 5, new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 8, 20, 0, 0) },
                    { 22, 5, new TimeSpan(0, 11, 25, 0, 0), new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "DayOfTheWeek", "End", "Start" },
                values: new object[] { 23, 5, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 35, 0, 0) });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "DayOfTheWeek", "End", "Start" },
                values: new object[] { 24, 5, new TimeSpan(0, 14, 55, 0, 0), new TimeSpan(0, 13, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "DayOfTheWeek", "End", "Start" },
                values: new object[] { 25, 5, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 15, 5, 0, 0) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4f978b96-c136-48d7-a2ae-c97238ab0c8d", "577b9340-1a02-4316-a983-42d70127751c" },
                    { "3aa603b2-ce9f-4c84-9dfe-cd6b56a74c30", "60d70ac4-f7ea-44c3-ba80-89fb25039b33" },
                    { "4f978b96-c136-48d7-a2ae-c97238ab0c8d", "8ed45042-5ce6-445b-a844-cf7a03eef945" },
                    { "3aa603b2-ce9f-4c84-9dfe-cd6b56a74c30", "a23b98d9-288f-424a-b307-3fc787a0005b" },
                    { "3aa603b2-ce9f-4c84-9dfe-cd6b56a74c30", "d21d4f10-82b7-409b-b447-15478ed6c6f2" },
                    { "4f978b96-c136-48d7-a2ae-c97238ab0c8d", "fc9a3784-05a1-4e14-8b00-2a0692d7a8ec" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyesId", "NameDepartment" },
                values: new object[] { 1, 1, "ИП" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Course", "DepartmentId", "NameGroup", "NumberGroup" },
                values: new object[,]
                {
                    { 1, 3, 1, "ИП", 2 },
                    { 2, 3, 1, "ИП", 1 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "DepartmentId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "577b9340-1a02-4316-a983-42d70127751c" },
                    { 2, 1, "fc9a3784-05a1-4e14-8b00-2a0692d7a8ec" },
                    { 3, 1, "577b9340-1a02-4316-a983-42d70127751c" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "DisciplinesId", "TypeSchedule", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 3, 1, 1 },
                    { 4, 1, 1, 1 },
                    { 5, 4, 0, 1 },
                    { 6, 4, 1, 1 },
                    { 7, 5, 1, 1 },
                    { 8, 9, 0, 1 },
                    { 9, 7, 1, 1 },
                    { 10, 6, 1, 1 },
                    { 11, 3, 0, 1 },
                    { 12, 5, 0, 1 },
                    { 13, 8, 1, 1 },
                    { 14, 9, 1, 1 },
                    { 15, 2, 0, 1 },
                    { 16, 8, 0, 1 },
                    { 17, 6, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CardNumber", "GroupsId", "UserId" },
                values: new object[,]
                {
                    { 1, "8252", 1, "d21d4f10-82b7-409b-b447-15478ed6c6f2" },
                    { 2, "2209", 1, "60d70ac4-f7ea-44c3-ba80-89fb25039b33" },
                    { 3, "3924", 1, "a23b98d9-288f-424a-b307-3fc787a0005b" }
                });

            migrationBuilder.InsertData(
                table: "GroupsSchedules",
                columns: new[] { "GroupsId", "SchedulesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 }
                });

            migrationBuilder.InsertData(
                table: "SlotsSchedules",
                columns: new[] { "Id", "SchedulesId", "SlotsId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 3 },
                    { 3, 3, 4 },
                    { 4, 4, 5 },
                    { 5, 5, 6 },
                    { 6, 6, 7 },
                    { 7, 8, 8 },
                    { 8, 9, 9 },
                    { 9, 10, 12 },
                    { 10, 11, 13 },
                    { 11, 12, 14 },
                    { 12, 13, 16 },
                    { 13, 14, 17 },
                    { 14, 15, 18 },
                    { 15, 9, 19 },
                    { 16, 7, 20 },
                    { 17, 16, 21 },
                    { 18, 17, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyesId",
                table: "Departments",
                column: "FacultyesId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentId",
                table: "Groups",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsSchedules_SchedulesId",
                table: "GroupsSchedules",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_PairsId",
                table: "Marks",
                column: "PairsId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_SlotScheduleId",
                table: "Pairs",
                column: "SlotScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DisciplinesId",
                table: "Schedules",
                column: "DisciplinesId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_WorkerId",
                table: "Schedules",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotsSchedules_SchedulesId",
                table: "SlotsSchedules",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotsSchedules_SlotsId",
                table: "SlotsSchedules",
                column: "SlotsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupsId",
                table: "Students",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GroupsSchedules");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SlotsSchedules");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Facultyes");
        }
    }
}
