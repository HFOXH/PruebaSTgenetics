CREATE DATABASE Stgnetics;
USE Stgnetics;

/* Create the table */
CREATE TABLE Animal(
    AnimalId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Breed VARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
    Sex VARCHAR(10) CHECK (Sex IN ('Male', 'Female')),
    Price DECIMAL(10, 2),
    Status VARCHAR(10) CHECK (Status IN ('Active', 'Inactive'))
);

/* Insert the data to test */
INSERT INTO Animal VALUES 
	('Bull1', 'Angus', '2020-01-15', 'Male', 500.00, 'Active'),
    ('Cow1', 'Holstein', '2019-04-10', 'Female', 400.00, 'Active'),
    ('Bull2', 'Hereford', '2021-02-20', 'Male', 550.00, 'Active'),
    ('Cow2', 'Jersey', '2018-07-05', 'Female', 450.00, 'Active'),
    ('Bull3', 'Simmental', '2019-11-30', 'Male', 600.00, 'Inactive'),
    ('Cow3', 'Angus', '2020-06-12', 'Female', 420.00, 'Active'),
    ('Bull4', 'Hereford', '2020-03-25', 'Male', 530.00, 'Active'),
    ('Cow4', 'Holstein', '2019-09-08', 'Female', 410.00, 'Active'),
    ('Bull5', 'Simmental', '2021-04-19', 'Male', 590.00, 'Active'),
    ('Cow5', 'Jersey', '2018-12-28', 'Female', 430.00, 'Inactive'),
    ('Bull6', 'Angus', '2019-03-22', 'Male', 520.00, 'Active'),
    ('Cow6', 'Hereford', '2020-10-15', 'Female', 440.00, 'Active'),
    ('Bull7', 'Simmental', '2018-05-07', 'Male', 580.00, 'Active'),
    ('Cow7', 'Jersey', '2021-07-03', 'Female', 460.00, 'Active'),
    ('Bull8', 'Angus', '2019-08-09', 'Male', 510.00, 'Active'),
    ('Cow8', 'Holstein', '2020-02-14', 'Female', 420.00, 'Inactive'),
    ('Bull9', 'Hereford', '2018-01-01', 'Male', 540.00, 'Active'),
    ('Cow9', 'Simmental', '2021-09-22', 'Female', 430.00, 'Active'),
    ('Bull10', 'Angus', '2020-06-05', 'Male', 560.00, 'Active'),
    ('Cow10', 'Holstein', '2019-12-10', 'Female', 450.00, 'Active');