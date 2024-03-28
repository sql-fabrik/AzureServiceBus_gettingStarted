DECLARE @now datetime    
SET     @now = GetDate() 

INSERT INTO dbo.Table01_toAustria      
       ( message_added, Lagerort )     
VALUES ( @now         , '0000000'     )
     , ( @now         , '01122'       )
     , ( @now         , '1020168'     )
     , ( @now         , '1234'        )
     , ( @now         , '1235'        )
     , ( @now         , '7077351'     )
     , ( @now         , '7166900'     )
     , ( @now         , 'BWT'         )
     , ( @now         , 'EXPORT'      )
     , ( @now         , 'EXPORT123'   )
     , ( @now         , 'V12345'      )
     , ( @now         , 'VKFB123456'  )
----
