﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class registryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardios");

            migrationBuilder.CreateTable(
                name: "Registries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(type: "int", nullable: false),
                    test01 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test02 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test03 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test04 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test05 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test06 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test07 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test08 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test09 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    test10 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registries");

            migrationBuilder.CreateTable(
                name: "Cardios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    air_circuit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cannula_problems = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cassette_id = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    center_id = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    clots = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    comment1 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    comment2 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    comment3 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    comment4 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    comment5 = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    conn_crack = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    contributor_id = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    cp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_ca = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_cp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_hy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_in = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_my = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_pda_1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_pda_2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_pda_3 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_pda_4 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_ta_1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_ta_2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cp_ta_3 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    date_death_followup = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    death_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    death_date_hours = table.Column<int>(type: "int", nullable: false),
                    death_date_minutes = table.Column<int>(type: "int", nullable: false),
                    discharge = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    discharge_hours = table.Column<int>(type: "int", nullable: false),
                    discharge_minutes = table.Column<int>(type: "int", nullable: false),
                    discharged_alive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    double_lumen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    extubation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    extubation_hours = table.Column<int>(type: "int", nullable: false),
                    extubation_minutes = table.Column<int>(type: "int", nullable: false),
                    heat_malf = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemo_ca = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemo_di = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemo_gi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemo_he = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemo_su = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hemodynamics = table.Column<byte[]>(type: "longblob", nullable: true),
                    indication = table.Column<int>(type: "int", nullable: false),
                    infect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    infect_cu = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    infect_wb = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    last_followup = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lldp = table.Column<int>(type: "int", nullable: false),
                    lldp_diam = table.Column<int>(type: "int", nullable: false),
                    lldp_length = table.Column<int>(type: "int", nullable: false),
                    meta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    meta_gl_1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    meta_gl_2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    meta_hy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    meta_ph_1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    meta_ph_2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neuro = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neuro_br = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neuro_ee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neuro_he = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neuro_in = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neuro_se = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    one_year_followup = table.Column<int>(type: "int", nullable: false),
                    ox_failure = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    page_1_complete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    page_2_complete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    page_3_complete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    page_4_complete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    page_5_complete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    patient_age = table.Column<int>(type: "int", nullable: false),
                    patient_gender = table.Column<int>(type: "int", nullable: false),
                    percutaneous_1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    percutaneous_2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    percutaneous_3 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pulm = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pulm_pn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pulm_pu = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pump_malf = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    reason_cardiac = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    reason_cns = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    reason_infection = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    reason_liver = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    reason_other = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    reason_pulmonary = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    registry_id = table.Column<int>(type: "int", nullable: false),
                    renal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    renal_ca = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    renal_cr_1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    renal_cr_2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    renal_di = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    renal_he = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    selected_age = table.Column<int>(type: "int", nullable: false),
                    selected_arrest = table.Column<int>(type: "int", nullable: false),
                    selected_btt = table.Column<int>(type: "int", nullable: false),
                    selected_cannulation_site_1 = table.Column<int>(type: "int", nullable: false),
                    selected_cannulation_site_2 = table.Column<int>(type: "int", nullable: false),
                    selected_cannulation_site_3 = table.Column<int>(type: "int", nullable: false),
                    selected_discharge_location = table.Column<int>(type: "int", nullable: false),
                    selected_fac = table.Column<int>(type: "int", nullable: false),
                    selected_height = table.Column<double>(type: "double", nullable: true),
                    selected_intubated = table.Column<int>(type: "int", nullable: false),
                    selected_length_1 = table.Column<int>(type: "int", nullable: false),
                    selected_length_2 = table.Column<int>(type: "int", nullable: false),
                    selected_length_3 = table.Column<int>(type: "int", nullable: false),
                    selected_reason = table.Column<int>(type: "int", nullable: false),
                    selected_reason_death = table.Column<int>(type: "int", nullable: false),
                    selected_repair = table.Column<int>(type: "int", nullable: false),
                    selected_size_1 = table.Column<int>(type: "int", nullable: false),
                    selected_size_2 = table.Column<int>(type: "int", nullable: false),
                    selected_size_3 = table.Column<int>(type: "int", nullable: false),
                    selected_vv_size = table.Column<int>(type: "int", nullable: false),
                    selected_weight = table.Column<double>(type: "double", nullable: true),
                    start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    start_hour = table.Column<int>(type: "int", nullable: false),
                    start_min = table.Column<int>(type: "int", nullable: false),
                    stop = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    stop_hour = table.Column<int>(type: "int", nullable: false),
                    stop_min = table.Column<int>(type: "int", nullable: false),
                    support_mode = table.Column<int>(type: "int", nullable: false),
                    support_mode_other = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    time_supported = table.Column<int>(type: "int", nullable: false),
                    tub_rupture = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardios", x => x.Id);
                });
        }
    }
}
