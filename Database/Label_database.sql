DROP DATABASE Label;

CREATE DATABASE Label;

USE Label;

CREATE TABLE labels (
LabelID int PRIMARY KEY NOT NULL,
SenderCompany varchar(255),
SenderName varchar(255) NOT NULL,
SenderSurname varchar(255),
SenderStreet varchar(255) NOT NULL,
SenderHomeNo varchar(255) NOT NULL,
SenderZip varchar(255) NOT NULL,
SenderCity varchar(255) NOT NULL,
ReceiverCompany varchar(255),
ReceiverName varchar(255) NOT NULL,
ReceiverSurname varchar(255),
ReceiverStreet varchar(255) NOT NULL,
ReceiverHomeNo varchar(255) NOT NULL,
ReceiverZip varchar(255) NOT NULL,
ReceiverCity varchar(255) NOT NULL,
ReceiverMobile varchar(255),
ReceiverEmail varchar(255),
DeliveryIns varchar(255),
Price varchar(255) NOT NULL,
Currency varchar(255) NOT NULL,
Weight varchar(255) NOT NULL
);
