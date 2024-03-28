CREATE TABLE dbo.Table01_toAustria (                         
             [ID]            bigint  IDENTITY(1,1) NOT NULL  
           , [message_added] datetime NULL                   
           , [message_toASB] datetime NULL                   
           , [Lagerort]      nvarchar(50)  NULL              
             CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED        
                         ( [ID] ASC )                        
           )                                                 

----
