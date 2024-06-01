USE OutpatientClinicDoctorDB
IF OBJECT_ID('tb_Doctor') IS NOT NULL
DROP TABLE tb_Doctor;
GO
CREATE TABLE tb_Doctor
	(No
		VARCHAR(50)
		NOT NULL
	CONSTRAINT pk_Doctor_No
		PRIMARY KEY(No)
	,Password
		VARCHAR(50)
	,Name
		VARCHAR(50)
	,Gender
		BIT
	,BirthDate
		DATE
	,IDCardNo
		VARCHAR(50)
	,Telephone
		VARCHAR(50)
	,QQEmail
		VARCHAR(50)
	,DepartmentNo
		INT
		CONSTRAINT fk_Doctor_DepartmentNo
		FOREIGN KEY (DepartmentNo)
		REFERENCES tb_Department(No)
		ON DELETE NO ACTION
		ON UPDATE CASCADE
	,TitleNo
		INT
		CONSTRAINT fk_Doctor_TitleNo
		FOREIGN KEY (TitleNo)
		REFERENCES tb_Title(No)
		ON DELETE NO ACTION
		ON UPDATE CASCADE
	,Introduction
		VARCHAR(250)
	,Avatar
		VARBINARY(MAX)
	,ErrorNumber
		INT
		DEFAULT 0
	,IsFreeze
		BIT
		DEFAULT 0)

INSERT INTO tb_Doctor
	(No,Password,Name,Gender,BirthDate,IDCardNo,Telephone,QQEmail,DepartmentNo,TitleNo,Introduction)
	VALUES
	('1989001',HASHBYTES('MD5','13022389239'),'������',1,'1961-3-23','350427196103234010','13022389239','3454634841@qq.com',10,1,'�ó�θ�����͸β�������'),
	('2008016',HASHBYTES('MD5','13028716229'),'������',0,'1989-5-29','350427198905293028','13028716229','2837482929@qq.com',25,2,'���١���״�ټ����ۺ����Σ���״�١����ɹ��ޡ��п��޵ȸ����޵�ǻ��΢������'),
	('2000009',HASHBYTES('MD5','13028716429'),'������',0,'1981-10-10','350427198110101826','13028716429','1928238145@qq.com',25,1,'����������������������ֳ����Ⱦ�Լ������¾����ࡢ������Ѫ��'),
	('2012003',HASHBYTES('MD5','13028716266'),'������',1,'1987-5-30','350427198705302313','13028716266','6574233172@qq.com',28,2,'�۵ײ����ư߼���������Ĥ���롢��������Ĥ���䡢�����ˡ��������Ѫ�������ϵ���������'),
	('1998025',HASHBYTES('MD5','13029878829'),'���ܹ�',1,'1966-6-2','350427196606024712','13029878829','2837666273@qq.com',26,1,'����֢���¾�ʧ����ʹ���Լ�������֢�����򲡡���״�ټ����Լ�����֢��'),
	('2018014',HASHBYTES('MD5','13028372839'),'ʩС��',0,'1988-12-5','350427198812055623','13028372839','3827648812@qq.com',23,2,'��������ʹ����ʹ����ʹ�ۺϹ�����ʧ���ĸߵ��ǽ���״̬����'),
	('2020032',HASHBYTES('MD5','13228372293'),'֣����',1,'1993-12-28','350427199312281112','13228372293','3948273771@qq.com',24,3,'����ʹ����׵������׵����ͻ��֢���������ɣ������ף��������ף�����ۺ�֢���ؽ���'),
	('2016008',HASHBYTES('MD5','13027382718'),'������',0,'1987-8-19','350427198708191426','13027382718','1119230293@qq.com',4,3,'��Ѫѹ����������˥�����Ĳ�������ʧ�����ļ�������Ѫ֬���ڿƳ�������������'),
	('1999011',HASHBYTES('MD5','13527839920'),'����',1,'1972-1-4','350427197201044318','13527839920','2837889898@qq.com',30,2,'�������������ȱ������ȱʧ����ֲ���ƣ������˵���ֲ��������������������������ʯ�����ܲ���������������');

SELECT * FROM tb_Doctor