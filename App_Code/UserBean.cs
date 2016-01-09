using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UserBean {
	
		private String name;
	     private String user;
	    private String Login;
		 private String Logout;
		 private String password;
		private Boolean valid;
	 private String email;
		 
	
		 public String getEmail() {
		        return email;
			}

		     public void setEmail(String newEmail) {
		        this.email = newEmail;
			}
		 
		     
			 
		 
		 
		 
		 
     public String getName() {
        return name;
	}

     public void setName(String newName) {
        this.name = newName;
	}
     
     public String getUser() {
         return user;
	}

     public void setUser(String newUser) {
         this.user = newUser;
	}
  
     
   
 	
			
    
     public String getLogin() {
         return Login;
			}

     public void setLogin(String newLogin) {
         this.Login = newLogin;
			}
     public String getLogout() {
          return Logout;
 			}

     public void setLogout(String newLogout) {
          this.Logout = newLogout;
 			}

   
          
     public String getPass() {
              return password;
      		}

     public void setPass(String newPass) {
              this.password = newPass;
      	}
        
           
     public Boolean isValid() {
               return  valid;
       		}

     public void setValid(Boolean newValid) {
               this.valid = newValid;
       	}
         
    
       
      	
        
          
}
