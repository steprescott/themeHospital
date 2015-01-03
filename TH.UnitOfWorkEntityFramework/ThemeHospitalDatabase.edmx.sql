
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/03/2015 01:39:08
-- Generated from EDMX file: D:\Documents\Uni\TH\TH.UnitOfWorkEntityFramework\ThemeHospitalDatabase.edmx
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
IF OBJECT_ID(N'[dbo].[FK_WardWaitingListWard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WardWaitingLists] DROP CONSTRAINT [FK_WardWaitingListWard];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitTeam_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitTeam] DROP CONSTRAINT [FK_VisitTeam_Visit];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitTeam] DROP CONSTRAINT [FK_VisitTeam_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultantSkill_Consultant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultantSkill] DROP CONSTRAINT [FK_ConsultantSkill_Consultant];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultantSkill_Skill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultantSkill] DROP CONSTRAINT [FK_ConsultantSkill_Skill];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitTreatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_VisitTreatment];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentRecordedBy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_TreatmentRecordedBy];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentAdministeredBy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_TreatmentAdministeredBy];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_TreatmentNote];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcedureOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_Procedure] DROP CONSTRAINT [FK_ProcedureOperation];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Doctor] DROP CONSTRAINT [FK_DoctorTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseOfMedicineMedicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_CourseOfMedicine] DROP CONSTRAINT [FK_CourseOfMedicineMedicine];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_PatientVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_PatientNote];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientWardWaitingList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Patient] DROP CONSTRAINT [FK_PatientWardWaitingList];
GO
IF OBJECT_ID(N'[dbo].[FK_BedVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_BedVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_BedWard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Beds] DROP CONSTRAINT [FK_BedWard];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_VisitNote];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultantTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_ConsultantTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentStaffMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_TreatmentStaffMember];
GO
IF OBJECT_ID(N'[dbo].[FK_RefusalNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Refusals] DROP CONSTRAINT [FK_RefusalNote];
GO
IF OBJECT_ID(N'[dbo].[FK_TreatmentRefusal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Refusals] DROP CONSTRAINT [FK_TreatmentRefusal];
GO
IF OBJECT_ID(N'[dbo].[FK_StaffMember_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_StaffMember] DROP CONSTRAINT [FK_StaffMember_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Consultant_inherits_StaffMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Consultant] DROP CONSTRAINT [FK_Consultant_inherits_StaffMember];
GO
IF OBJECT_ID(N'[dbo].[FK_Procedure_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_Procedure] DROP CONSTRAINT [FK_Procedure_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_Doctor_inherits_StaffMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Doctor] DROP CONSTRAINT [FK_Doctor_inherits_StaffMember];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseOfMedicine_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_CourseOfMedicine] DROP CONSTRAINT [FK_CourseOfMedicine_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_Patient_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Patient] DROP CONSTRAINT [FK_Patient_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Receptionist_inherits_StaffMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Receptionist] DROP CONSTRAINT [FK_Receptionist_inherits_StaffMember];
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
IF OBJECT_ID(N'[dbo].[Refusals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Refusals];
GO
IF OBJECT_ID(N'[dbo].[Users_StaffMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_StaffMember];
GO
IF OBJECT_ID(N'[dbo].[Users_Consultant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Consultant];
GO
IF OBJECT_ID(N'[dbo].[Treatments_Procedure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_Procedure];
GO
IF OBJECT_ID(N'[dbo].[Users_Doctor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Doctor];
GO
IF OBJECT_ID(N'[dbo].[Treatments_CourseOfMedicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_CourseOfMedicine];
GO
IF OBJECT_ID(N'[dbo].[Users_Patient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Patient];
GO
IF OBJECT_ID(N'[dbo].[Users_Receptionist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Receptionist];
GO
IF OBJECT_ID(N'[dbo].[UserAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAddress];
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
    [VisitId] uniqueidentifier  NOT NULL,
    [RecordedByUserId] uniqueidentifier  NOT NULL,
    [AdministeredByUserId] uniqueidentifier  NULL,
    [AssignedToUserId] uniqueidentifier  NOT NULL
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
    [WardId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [NoteId] uniqueidentifier  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [TreatmentId] uniqueidentifier  NULL,
    [PatientUserId] uniqueidentifier  NULL,
    [VisitId] uniqueidentifier  NULL
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
    [ReleaseDate] datetime  NULL,
    [PatientUserId] uniqueidentifier  NOT NULL,
    [BedId] uniqueidentifier  NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [SkillId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Refusals'
CREATE TABLE [dbo].[Refusals] (
    [RefusalId] uniqueidentifier  NOT NULL,
    [Note_NoteId] uniqueidentifier  NOT NULL,
    [Treatment_TreatmentId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_StaffMember'
CREATE TABLE [dbo].[Users_StaffMember] (
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [LastLoggedIn] datetime  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Consultant'
CREATE TABLE [dbo].[Users_Consultant] (
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_Procedure'
CREATE TABLE [dbo].[Treatments_Procedure] (
    [DateAdministered] datetime  NULL,
    [OperationId] uniqueidentifier  NOT NULL,
    [TreatmentId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Doctor'
CREATE TABLE [dbo].[Users_Doctor] (
    [TeamId] uniqueidentifier  NULL,
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_CourseOfMedicine'
CREATE TABLE [dbo].[Treatments_CourseOfMedicine] (
    [EndDate] datetime  NOT NULL,
    [Instructions] nvarchar(max)  NOT NULL,
    [MedicineId] uniqueidentifier  NOT NULL,
    [TreatmentId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Patient'
CREATE TABLE [dbo].[Users_Patient] (
    [EmergencyContactName] nvarchar(max)  NOT NULL,
    [EmergencyContactNumber] nvarchar(max)  NOT NULL,
    [WardWaitingListId] uniqueidentifier  NULL,
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

-- Creating primary key on [RefusalId] in table 'Refusals'
ALTER TABLE [dbo].[Refusals]
ADD CONSTRAINT [PK_Refusals]
    PRIMARY KEY CLUSTERED ([RefusalId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_StaffMember'
ALTER TABLE [dbo].[Users_StaffMember]
ADD CONSTRAINT [PK_Users_StaffMember]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Consultant'
ALTER TABLE [dbo].[Users_Consultant]
ADD CONSTRAINT [PK_Users_Consultant]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [TreatmentId] in table 'Treatments_Procedure'
ALTER TABLE [dbo].[Treatments_Procedure]
ADD CONSTRAINT [PK_Treatments_Procedure]
    PRIMARY KEY CLUSTERED ([TreatmentId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Doctor'
ALTER TABLE [dbo].[Users_Doctor]
ADD CONSTRAINT [PK_Users_Doctor]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [TreatmentId] in table 'Treatments_CourseOfMedicine'
ALTER TABLE [dbo].[Treatments_CourseOfMedicine]
ADD CONSTRAINT [PK_Treatments_CourseOfMedicine]
    PRIMARY KEY CLUSTERED ([TreatmentId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Patient'
ALTER TABLE [dbo].[Users_Patient]
ADD CONSTRAINT [PK_Users_Patient]
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

-- Creating foreign key on [VisitId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_VisitTreatment]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([VisitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitTreatment'
CREATE INDEX [IX_FK_VisitTreatment]
ON [dbo].[Treatments]
    ([VisitId]);
GO

-- Creating foreign key on [RecordedByUserId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_TreatmentRecordedBy]
    FOREIGN KEY ([RecordedByUserId])
    REFERENCES [dbo].[Users_StaffMember]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentRecordedBy'
CREATE INDEX [IX_FK_TreatmentRecordedBy]
ON [dbo].[Treatments]
    ([RecordedByUserId]);
GO

-- Creating foreign key on [AdministeredByUserId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_TreatmentAdministeredBy]
    FOREIGN KEY ([AdministeredByUserId])
    REFERENCES [dbo].[Users_StaffMember]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentAdministeredBy'
CREATE INDEX [IX_FK_TreatmentAdministeredBy]
ON [dbo].[Treatments]
    ([AdministeredByUserId]);
GO

-- Creating foreign key on [TreatmentId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_TreatmentNote]
    FOREIGN KEY ([TreatmentId])
    REFERENCES [dbo].[Treatments]
        ([TreatmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentNote'
CREATE INDEX [IX_FK_TreatmentNote]
ON [dbo].[Notes]
    ([TreatmentId]);
GO

-- Creating foreign key on [OperationId] in table 'Treatments_Procedure'
ALTER TABLE [dbo].[Treatments_Procedure]
ADD CONSTRAINT [FK_ProcedureOperation]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([OperationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcedureOperation'
CREATE INDEX [IX_FK_ProcedureOperation]
ON [dbo].[Treatments_Procedure]
    ([OperationId]);
GO

-- Creating foreign key on [TeamId] in table 'Users_Doctor'
ALTER TABLE [dbo].[Users_Doctor]
ADD CONSTRAINT [FK_DoctorTeam]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Teams]
        ([TeamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorTeam'
CREATE INDEX [IX_FK_DoctorTeam]
ON [dbo].[Users_Doctor]
    ([TeamId]);
GO

-- Creating foreign key on [MedicineId] in table 'Treatments_CourseOfMedicine'
ALTER TABLE [dbo].[Treatments_CourseOfMedicine]
ADD CONSTRAINT [FK_CourseOfMedicineMedicine]
    FOREIGN KEY ([MedicineId])
    REFERENCES [dbo].[Medicines]
        ([MedicineId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseOfMedicineMedicine'
CREATE INDEX [IX_FK_CourseOfMedicineMedicine]
ON [dbo].[Treatments_CourseOfMedicine]
    ([MedicineId]);
GO

-- Creating foreign key on [PatientUserId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_PatientVisit]
    FOREIGN KEY ([PatientUserId])
    REFERENCES [dbo].[Users_Patient]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientVisit'
CREATE INDEX [IX_FK_PatientVisit]
ON [dbo].[Visits]
    ([PatientUserId]);
GO

-- Creating foreign key on [PatientUserId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_PatientNote]
    FOREIGN KEY ([PatientUserId])
    REFERENCES [dbo].[Users_Patient]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientNote'
CREATE INDEX [IX_FK_PatientNote]
ON [dbo].[Notes]
    ([PatientUserId]);
GO

-- Creating foreign key on [WardWaitingListId] in table 'Users_Patient'
ALTER TABLE [dbo].[Users_Patient]
ADD CONSTRAINT [FK_PatientWardWaitingList]
    FOREIGN KEY ([WardWaitingListId])
    REFERENCES [dbo].[WardWaitingLists]
        ([WardWaitingListId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientWardWaitingList'
CREATE INDEX [IX_FK_PatientWardWaitingList]
ON [dbo].[Users_Patient]
    ([WardWaitingListId]);
GO

-- Creating foreign key on [BedId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_BedVisit]
    FOREIGN KEY ([BedId])
    REFERENCES [dbo].[Beds]
        ([BedId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BedVisit'
CREATE INDEX [IX_FK_BedVisit]
ON [dbo].[Visits]
    ([BedId]);
GO

-- Creating foreign key on [WardId] in table 'Beds'
ALTER TABLE [dbo].[Beds]
ADD CONSTRAINT [FK_BedWard]
    FOREIGN KEY ([WardId])
    REFERENCES [dbo].[Wards]
        ([WardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BedWard'
CREATE INDEX [IX_FK_BedWard]
ON [dbo].[Beds]
    ([WardId]);
GO

-- Creating foreign key on [VisitId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_VisitNote]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([VisitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitNote'
CREATE INDEX [IX_FK_VisitNote]
ON [dbo].[Notes]
    ([VisitId]);
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

-- Creating foreign key on [AssignedToUserId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_TreatmentStaffMember]
    FOREIGN KEY ([AssignedToUserId])
    REFERENCES [dbo].[Users_StaffMember]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentStaffMember'
CREATE INDEX [IX_FK_TreatmentStaffMember]
ON [dbo].[Treatments]
    ([AssignedToUserId]);
GO

-- Creating foreign key on [Note_NoteId] in table 'Refusals'
ALTER TABLE [dbo].[Refusals]
ADD CONSTRAINT [FK_RefusalNote]
    FOREIGN KEY ([Note_NoteId])
    REFERENCES [dbo].[Notes]
        ([NoteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RefusalNote'
CREATE INDEX [IX_FK_RefusalNote]
ON [dbo].[Refusals]
    ([Note_NoteId]);
GO

-- Creating foreign key on [Treatment_TreatmentId] in table 'Refusals'
ALTER TABLE [dbo].[Refusals]
ADD CONSTRAINT [FK_TreatmentRefusal]
    FOREIGN KEY ([Treatment_TreatmentId])
    REFERENCES [dbo].[Treatments]
        ([TreatmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreatmentRefusal'
CREATE INDEX [IX_FK_TreatmentRefusal]
ON [dbo].[Refusals]
    ([Treatment_TreatmentId]);
GO

-- Creating foreign key on [UserId] in table 'Users_StaffMember'
ALTER TABLE [dbo].[Users_StaffMember]
ADD CONSTRAINT [FK_StaffMember_inherits_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_Consultant'
ALTER TABLE [dbo].[Users_Consultant]
ADD CONSTRAINT [FK_Consultant_inherits_StaffMember]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_StaffMember]
        ([UserId])
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

-- Creating foreign key on [UserId] in table 'Users_Doctor'
ALTER TABLE [dbo].[Users_Doctor]
ADD CONSTRAINT [FK_Doctor_inherits_StaffMember]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_StaffMember]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TreatmentId] in table 'Treatments_CourseOfMedicine'
ALTER TABLE [dbo].[Treatments_CourseOfMedicine]
ADD CONSTRAINT [FK_CourseOfMedicine_inherits_Treatment]
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

-- Creating foreign key on [UserId] in table 'Users_Receptionist'
ALTER TABLE [dbo].[Users_Receptionist]
ADD CONSTRAINT [FK_Receptionist_inherits_StaffMember]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_StaffMember]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------