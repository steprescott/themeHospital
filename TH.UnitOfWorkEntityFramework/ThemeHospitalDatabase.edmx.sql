
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/11/2014 22:49:41
-- Generated from EDMX file: C:\Users\Jonathan\documents\visual studio 2013\Projects\Theme Hospital\TH.UnitOfWorkEntityFramework\ThemeHospitalDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ThemeHospital];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserAddress_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAddress] DROP CONSTRAINT [FK_UserAddress_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAddress_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAddress] DROP CONSTRAINT [FK_UserAddress_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseOfMedicineMedicine_CauseOfMedicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CauseOfMedicineMedicine] DROP CONSTRAINT [FK_CauseOfMedicineMedicine_CauseOfMedicine];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseOfMedicineMedicine_Medicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CauseOfMedicineMedicine] DROP CONSTRAINT [FK_CauseOfMedicineMedicine_Medicine];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcedureOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_Procedure] DROP CONSTRAINT [FK_ProcedureOperation];
GO
IF OBJECT_ID(N'[dbo].[FK_WardWaitingListWard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WardWaitingLists] DROP CONSTRAINT [FK_WardWaitingListWard];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_PatientVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitBed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_VisitBed];
GO
IF OBJECT_ID(N'[dbo].[FK_WardWaitingListPatient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Patient] DROP CONSTRAINT [FK_WardWaitingListPatient];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentStaffMemeber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_TreatmentStaffMemeber];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentStaffMemeber1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_TreatmentStaffMemeber1];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_PatientNote];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Doctor] DROP CONSTRAINT [FK_DoctorTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultantTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_ConsultantTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitTeam_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitTeam] DROP CONSTRAINT [FK_VisitTeam_Visit];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitTeam] DROP CONSTRAINT [FK_VisitTeam_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_TreatmentVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultantSkill_Consultant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultantSkill] DROP CONSTRAINT [FK_ConsultantSkill_Consultant];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultantSkill_Skill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultantSkill] DROP CONSTRAINT [FK_ConsultantSkill_Skill];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_TreatmentNote];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_VisitNote];
GO
IF OBJECT_ID(N'[dbo].[FK_WardBed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Beds] DROP CONSTRAINT [FK_WardBed];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseOfMedicine_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_CourseOfMedicine] DROP CONSTRAINT [FK_CourseOfMedicine_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_Procedure_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_Procedure] DROP CONSTRAINT [FK_Procedure_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_Patient_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Patient] DROP CONSTRAINT [FK_Patient_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_StaffMemeber_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_StaffMemeber] DROP CONSTRAINT [FK_StaffMemeber_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Doctor_inherits_StaffMemeber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Doctor] DROP CONSTRAINT [FK_Doctor_inherits_StaffMemeber];
GO
IF OBJECT_ID(N'[dbo].[FK_Consultant_inherits_StaffMemeber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Consultant] DROP CONSTRAINT [FK_Consultant_inherits_StaffMemeber];
GO
IF OBJECT_ID(N'[dbo].[FK_Receptionist_inherits_StaffMemeber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Receptionist] DROP CONSTRAINT [FK_Receptionist_inherits_StaffMemeber];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[Treatments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments];
GO
IF OBJECT_ID(N'[dbo].[Medicines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicines];
GO
IF OBJECT_ID(N'[dbo].[Operations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operations];
GO
IF OBJECT_ID(N'[dbo].[Wards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wards];
GO
IF OBJECT_ID(N'[dbo].[Beds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Beds];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[WardWaitingLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WardWaitingLists];
GO
IF OBJECT_ID(N'[dbo].[Visits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visits];
GO
IF OBJECT_ID(N'[dbo].[Skills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skills];
GO
IF OBJECT_ID(N'[dbo].[Treatments_CourseOfMedicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_CourseOfMedicine];
GO
IF OBJECT_ID(N'[dbo].[Treatments_Procedure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_Procedure];
GO
IF OBJECT_ID(N'[dbo].[Users_Patient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Patient];
GO
IF OBJECT_ID(N'[dbo].[Users_StaffMemeber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_StaffMemeber];
GO
IF OBJECT_ID(N'[dbo].[Users_Doctor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Doctor];
GO
IF OBJECT_ID(N'[dbo].[Users_Consultant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Consultant];
GO
IF OBJECT_ID(N'[dbo].[Users_Receptionist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Receptionist];
GO
IF OBJECT_ID(N'[dbo].[UserAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAddress];
GO
IF OBJECT_ID(N'[dbo].[CauseOfMedicineMedicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CauseOfMedicineMedicine];
GO
IF OBJECT_ID(N'[dbo].[VisitTeam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitTeam];
GO
IF OBJECT_ID(N'[dbo].[ConsultantSkill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsultantSkill];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [OtherNames] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [ContactNumber] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] uniqueidentifier  NOT NULL,
    [AddressLine1] nvarchar(max)  NOT NULL,
    [AddressLine2] nvarchar(max)  NOT NULL,
    [AddressLine3] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [PostCode] nvarchar(max)  NOT NULL,
    [IsCurrentAddress] bit  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [TeamId] uniqueidentifier  NOT NULL,
    [Consultant_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments'
CREATE TABLE [dbo].[Treatments] (
    [TreatmentId] uniqueidentifier  NOT NULL,
    [ScheduledDate] datetime  NOT NULL,
    [RecordedBy_UserId] uniqueidentifier  NOT NULL,
    [AdministeredBy_UserId] uniqueidentifier  NOT NULL,
    [Visit_VisitId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Medicines'
CREATE TABLE [dbo].[Medicines] (
    [MedicineId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [OperationId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Wards'
CREATE TABLE [dbo].[Wards] (
    [WardId] uniqueidentifier  NOT NULL,
    [Number] int  NOT NULL
);
GO

-- Creating table 'Beds'
CREATE TABLE [dbo].[Beds] (
    [BedId] uniqueidentifier  NOT NULL,
    [Number] int  NOT NULL,
    [Ward_WardId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [NoteId] uniqueidentifier  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Patient_UserId] uniqueidentifier  NULL,
    [Treatment_TreatmentId] uniqueidentifier  NOT NULL,
    [Visit_VisitId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'WardWaitingLists'
CREATE TABLE [dbo].[WardWaitingLists] (
    [WardWaitingListId] uniqueidentifier  NOT NULL,
    [Ward_WardId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Visits'
CREATE TABLE [dbo].[Visits] (
    [VisitId] uniqueidentifier  NOT NULL,
    [AdmittedDate] datetime  NOT NULL,
    [ReleaseDate] datetime  NOT NULL,
    [Patient_UserId] uniqueidentifier  NOT NULL,
    [Bed_BedId] uniqueidentifier  NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [SkillId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Treatments_CourseOfMedicine'
CREATE TABLE [dbo].[Treatments_CourseOfMedicine] (
    [StartDate] nvarchar(max)  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL,
    [Instructions] nvarchar(max)  NOT NULL,
    [TreatmentId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_Procedure'
CREATE TABLE [dbo].[Treatments_Procedure] (
    [DateAdministered] datetime  NOT NULL,
    [TreatmentId] uniqueidentifier  NOT NULL,
    [Operation_OperationId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Patient'
CREATE TABLE [dbo].[Users_Patient] (
    [EmergencyContactName] nvarchar(max)  NOT NULL,
    [EmergencyContactNumber] nvarchar(max)  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [WardWaitingList_WardWaitingListId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_StaffMemeber'
CREATE TABLE [dbo].[Users_StaffMemeber] (
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [LastLoggedIn] datetime  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Doctor'
CREATE TABLE [dbo].[Users_Doctor] (
    [UserId] uniqueidentifier  NOT NULL,
    [Team_TeamId] uniqueidentifier  NULL
);
GO

-- Creating table 'Users_Consultant'
CREATE TABLE [dbo].[Users_Consultant] (
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Receptionist'
CREATE TABLE [dbo].[Users_Receptionist] (
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UserAddress'
CREATE TABLE [dbo].[UserAddress] (
    [Users_UserId] uniqueidentifier  NOT NULL,
    [Addresses_AddressId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CauseOfMedicineMedicine'
CREATE TABLE [dbo].[CauseOfMedicineMedicine] (
    [CourseOfMedicine_TreatmentId] uniqueidentifier  NOT NULL,
    [Medicines_MedicineId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'VisitTeam'
CREATE TABLE [dbo].[VisitTeam] (
    [Visits_VisitId] uniqueidentifier  NOT NULL,
    [Teams_TeamId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ConsultantSkill'
CREATE TABLE [dbo].[ConsultantSkill] (
    [Consultants_UserId] uniqueidentifier  NOT NULL,
    [Skills_SkillId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [TeamId] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([TeamId] ASC);
GO

-- Creating primary key on [TreatmentId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [PK_Treatments]
    PRIMARY KEY CLUSTERED ([TreatmentId] ASC);
GO

-- Creating primary key on [MedicineId] in table 'Medicines'
ALTER TABLE [dbo].[Medicines]
ADD CONSTRAINT [PK_Medicines]
    PRIMARY KEY CLUSTERED ([MedicineId] ASC);
GO

-- Creating primary key on [OperationId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([OperationId] ASC);
GO

-- Creating primary key on [WardId] in table 'Wards'
ALTER TABLE [dbo].[Wards]
ADD CONSTRAINT [PK_Wards]
    PRIMARY KEY CLUSTERED ([WardId] ASC);
GO

-- Creating primary key on [BedId] in table 'Beds'
ALTER TABLE [dbo].[Beds]
ADD CONSTRAINT [PK_Beds]
    PRIMARY KEY CLUSTERED ([BedId] ASC);
GO

-- Creating primary key on [NoteId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([NoteId] ASC);
GO

-- Creating primary key on [WardWaitingListId] in table 'WardWaitingLists'
ALTER TABLE [dbo].[WardWaitingLists]
ADD CONSTRAINT [PK_WardWaitingLists]
    PRIMARY KEY CLUSTERED ([WardWaitingListId] ASC);
GO

-- Creating primary key on [VisitId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [PK_Visits]
    PRIMARY KEY CLUSTERED ([VisitId] ASC);
GO

-- Creating primary key on [SkillId] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [PK_Skills]
    PRIMARY KEY CLUSTERED ([SkillId] ASC);
GO

-- Creating primary key on [TreatmentId] in table 'Treatments_CourseOfMedicine'
ALTER TABLE [dbo].[Treatments_CourseOfMedicine]
ADD CONSTRAINT [PK_Treatments_CourseOfMedicine]
    PRIMARY KEY CLUSTERED ([TreatmentId] ASC);
GO

-- Creating primary key on [TreatmentId] in table 'Treatments_Procedure'
ALTER TABLE [dbo].[Treatments_Procedure]
ADD CONSTRAINT [PK_Treatments_Procedure]
    PRIMARY KEY CLUSTERED ([TreatmentId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Patient'
ALTER TABLE [dbo].[Users_Patient]
ADD CONSTRAINT [PK_Users_Patient]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_StaffMemeber'
ALTER TABLE [dbo].[Users_StaffMemeber]
ADD CONSTRAINT [PK_Users_StaffMemeber]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Doctor'
ALTER TABLE [dbo].[Users_Doctor]
ADD CONSTRAINT [PK_Users_Doctor]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Consultant'
ALTER TABLE [dbo].[Users_Consultant]
ADD CONSTRAINT [PK_Users_Consultant]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Receptionist'
ALTER TABLE [dbo].[Users_Receptionist]
ADD CONSTRAINT [PK_Users_Receptionist]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Users_UserId], [Addresses_AddressId] in table 'UserAddress'
ALTER TABLE [dbo].[UserAddress]
ADD CONSTRAINT [PK_UserAddress]
    PRIMARY KEY CLUSTERED ([Users_UserId], [Addresses_AddressId] ASC);
GO

-- Creating primary key on [CourseOfMedicine_TreatmentId], [Medicines_MedicineId] in table 'CauseOfMedicineMedicine'
ALTER TABLE [dbo].[CauseOfMedicineMedicine]
ADD CONSTRAINT [PK_CauseOfMedicineMedicine]
    PRIMARY KEY CLUSTERED ([CourseOfMedicine_TreatmentId], [Medicines_MedicineId] ASC);
GO

-- Creating primary key on [Visits_VisitId], [Teams_TeamId] in table 'VisitTeam'
ALTER TABLE [dbo].[VisitTeam]
ADD CONSTRAINT [PK_VisitTeam]
    PRIMARY KEY CLUSTERED ([Visits_VisitId], [Teams_TeamId] ASC);
GO

-- Creating primary key on [Consultants_UserId], [Skills_SkillId] in table 'ConsultantSkill'
ALTER TABLE [dbo].[ConsultantSkill]
ADD CONSTRAINT [PK_ConsultantSkill]
    PRIMARY KEY CLUSTERED ([Consultants_UserId], [Skills_SkillId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_UserId] in table 'UserAddress'
ALTER TABLE [dbo].[UserAddress]
ADD CONSTRAINT [FK_UserAddress_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Addresses_AddressId] in table 'UserAddress'
ALTER TABLE [dbo].[UserAddress]
ADD CONSTRAINT [FK_UserAddress_Address]
    FOREIGN KEY ([Addresses_AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAddress_Address'
CREATE INDEX [IX_FK_UserAddress_Address]
ON [dbo].[UserAddress]
    ([Addresses_AddressId]);
GO

-- Creating foreign key on [CourseOfMedicine_TreatmentId] in table 'CauseOfMedicineMedicine'
ALTER TABLE [dbo].[CauseOfMedicineMedicine]
ADD CONSTRAINT [FK_CauseOfMedicineMedicine_CauseOfMedicine]
    FOREIGN KEY ([CourseOfMedicine_TreatmentId])
    REFERENCES [dbo].[Treatments_CourseOfMedicine]
        ([TreatmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Medicines_MedicineId] in table 'CauseOfMedicineMedicine'
ALTER TABLE [dbo].[CauseOfMedicineMedicine]
ADD CONSTRAINT [FK_CauseOfMedicineMedicine_Medicine]
    FOREIGN KEY ([Medicines_MedicineId])
    REFERENCES [dbo].[Medicines]
        ([MedicineId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseOfMedicineMedicine_Medicine'
CREATE INDEX [IX_FK_CauseOfMedicineMedicine_Medicine]
ON [dbo].[CauseOfMedicineMedicine]
    ([Medicines_MedicineId]);
GO

-- Creating foreign key on [Operation_OperationId] in table 'Treatments_Procedure'
ALTER TABLE [dbo].[Treatments_Procedure]
ADD CONSTRAINT [FK_ProcedureOperation]
    FOREIGN KEY ([Operation_OperationId])
    REFERENCES [dbo].[Operations]
        ([OperationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcedureOperation'
CREATE INDEX [IX_FK_ProcedureOperation]
ON [dbo].[Treatments_Procedure]
    ([Operation_OperationId]);
GO

-- Creating foreign key on [Ward_WardId] in table 'WardWaitingLists'
ALTER TABLE [dbo].[WardWaitingLists]
ADD CONSTRAINT [FK_WardWaitingListWard]
    FOREIGN KEY ([Ward_WardId])
    REFERENCES [dbo].[Wards]
        ([WardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WardWaitingListWard'
CREATE INDEX [IX_FK_WardWaitingListWard]
ON [dbo].[WardWaitingLists]
    ([Ward_WardId]);
GO

-- Creating foreign key on [Patient_UserId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_PatientVisit]
    FOREIGN KEY ([Patient_UserId])
    REFERENCES [dbo].[Users_Patient]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientVisit'
CREATE INDEX [IX_FK_PatientVisit]
ON [dbo].[Visits]
    ([Patient_UserId]);
GO

-- Creating foreign key on [Bed_BedId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_VisitBed]
    FOREIGN KEY ([Bed_BedId])
    REFERENCES [dbo].[Beds]
        ([BedId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitBed'
CREATE INDEX [IX_FK_VisitBed]
ON [dbo].[Visits]
    ([Bed_BedId]);
GO

-- Creating foreign key on [WardWaitingList_WardWaitingListId] in table 'Users_Patient'
ALTER TABLE [dbo].[Users_Patient]
ADD CONSTRAINT [FK_WardWaitingListPatient]
    FOREIGN KEY ([WardWaitingList_WardWaitingListId])
    REFERENCES [dbo].[WardWaitingLists]
        ([WardWaitingListId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WardWaitingListPatient'
CREATE INDEX [IX_FK_WardWaitingListPatient]
ON [dbo].[Users_Patient]
    ([WardWaitingList_WardWaitingListId]);
GO

-- Creating foreign key on [RecordedBy_UserId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_TreatmentStaffMemeber]
    FOREIGN KEY ([RecordedBy_UserId])
    REFERENCES [dbo].[Users_StaffMemeber]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentStaffMemeber'
CREATE INDEX [IX_FK_TreatmentStaffMemeber]
ON [dbo].[Treatments]
    ([RecordedBy_UserId]);
GO

-- Creating foreign key on [AdministeredBy_UserId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_TreatmentStaffMemeber1]
    FOREIGN KEY ([AdministeredBy_UserId])
    REFERENCES [dbo].[Users_StaffMemeber]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentStaffMemeber1'
CREATE INDEX [IX_FK_TreatmentStaffMemeber1]
ON [dbo].[Treatments]
    ([AdministeredBy_UserId]);
GO

-- Creating foreign key on [Patient_UserId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_PatientNote]
    FOREIGN KEY ([Patient_UserId])
    REFERENCES [dbo].[Users_Patient]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientNote'
CREATE INDEX [IX_FK_PatientNote]
ON [dbo].[Notes]
    ([Patient_UserId]);
GO

-- Creating foreign key on [Team_TeamId] in table 'Users_Doctor'
ALTER TABLE [dbo].[Users_Doctor]
ADD CONSTRAINT [FK_DoctorTeam]
    FOREIGN KEY ([Team_TeamId])
    REFERENCES [dbo].[Teams]
        ([TeamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorTeam'
CREATE INDEX [IX_FK_DoctorTeam]
ON [dbo].[Users_Doctor]
    ([Team_TeamId]);
GO

-- Creating foreign key on [Consultant_UserId] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_ConsultantTeam]
    FOREIGN KEY ([Consultant_UserId])
    REFERENCES [dbo].[Users_Consultant]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsultantTeam'
CREATE INDEX [IX_FK_ConsultantTeam]
ON [dbo].[Teams]
    ([Consultant_UserId]);
GO

-- Creating foreign key on [Visits_VisitId] in table 'VisitTeam'
ALTER TABLE [dbo].[VisitTeam]
ADD CONSTRAINT [FK_VisitTeam_Visit]
    FOREIGN KEY ([Visits_VisitId])
    REFERENCES [dbo].[Visits]
        ([VisitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teams_TeamId] in table 'VisitTeam'
ALTER TABLE [dbo].[VisitTeam]
ADD CONSTRAINT [FK_VisitTeam_Team]
    FOREIGN KEY ([Teams_TeamId])
    REFERENCES [dbo].[Teams]
        ([TeamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitTeam_Team'
CREATE INDEX [IX_FK_VisitTeam_Team]
ON [dbo].[VisitTeam]
    ([Teams_TeamId]);
GO

-- Creating foreign key on [Visit_VisitId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_TreatmentVisit]
    FOREIGN KEY ([Visit_VisitId])
    REFERENCES [dbo].[Visits]
        ([VisitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentVisit'
CREATE INDEX [IX_FK_TreatmentVisit]
ON [dbo].[Treatments]
    ([Visit_VisitId]);
GO

-- Creating foreign key on [Consultants_UserId] in table 'ConsultantSkill'
ALTER TABLE [dbo].[ConsultantSkill]
ADD CONSTRAINT [FK_ConsultantSkill_Consultant]
    FOREIGN KEY ([Consultants_UserId])
    REFERENCES [dbo].[Users_Consultant]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Skills_SkillId] in table 'ConsultantSkill'
ALTER TABLE [dbo].[ConsultantSkill]
ADD CONSTRAINT [FK_ConsultantSkill_Skill]
    FOREIGN KEY ([Skills_SkillId])
    REFERENCES [dbo].[Skills]
        ([SkillId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsultantSkill_Skill'
CREATE INDEX [IX_FK_ConsultantSkill_Skill]
ON [dbo].[ConsultantSkill]
    ([Skills_SkillId]);
GO

-- Creating foreign key on [Treatment_TreatmentId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_TreatmentNote]
    FOREIGN KEY ([Treatment_TreatmentId])
    REFERENCES [dbo].[Treatments]
        ([TreatmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentNote'
CREATE INDEX [IX_FK_TreatmentNote]
ON [dbo].[Notes]
    ([Treatment_TreatmentId]);
GO

-- Creating foreign key on [Visit_VisitId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_VisitNote]
    FOREIGN KEY ([Visit_VisitId])
    REFERENCES [dbo].[Visits]
        ([VisitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitNote'
CREATE INDEX [IX_FK_VisitNote]
ON [dbo].[Notes]
    ([Visit_VisitId]);
GO

-- Creating foreign key on [Ward_WardId] in table 'Beds'
ALTER TABLE [dbo].[Beds]
ADD CONSTRAINT [FK_WardBed]
    FOREIGN KEY ([Ward_WardId])
    REFERENCES [dbo].[Wards]
        ([WardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WardBed'
CREATE INDEX [IX_FK_WardBed]
ON [dbo].[Beds]
    ([Ward_WardId]);
GO

-- Creating foreign key on [TreatmentId] in table 'Treatments_CourseOfMedicine'
ALTER TABLE [dbo].[Treatments_CourseOfMedicine]
ADD CONSTRAINT [FK_CourseOfMedicine_inherits_Treatment]
    FOREIGN KEY ([TreatmentId])
    REFERENCES [dbo].[Treatments]
        ([TreatmentId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TreatmentId] in table 'Treatments_Procedure'
ALTER TABLE [dbo].[Treatments_Procedure]
ADD CONSTRAINT [FK_Procedure_inherits_Treatment]
    FOREIGN KEY ([TreatmentId])
    REFERENCES [dbo].[Treatments]
        ([TreatmentId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_Patient'
ALTER TABLE [dbo].[Users_Patient]
ADD CONSTRAINT [FK_Patient_inherits_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_StaffMemeber'
ALTER TABLE [dbo].[Users_StaffMemeber]
ADD CONSTRAINT [FK_StaffMemeber_inherits_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_Doctor'
ALTER TABLE [dbo].[Users_Doctor]
ADD CONSTRAINT [FK_Doctor_inherits_StaffMemeber]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_StaffMemeber]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_Consultant'
ALTER TABLE [dbo].[Users_Consultant]
ADD CONSTRAINT [FK_Consultant_inherits_StaffMemeber]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_StaffMemeber]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_Receptionist'
ALTER TABLE [dbo].[Users_Receptionist]
ADD CONSTRAINT [FK_Receptionist_inherits_StaffMemeber]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_StaffMemeber]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------