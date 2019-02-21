Feature: SpecFlowCheck


Scenario: 1. User checks a main menu navigation
 Given user go to Google page 
 Then I verify that a main Google page locators are shown
| PageElementName | CssLocators                                          |
| MainLogo        | #hplogo                                              |
| MailButton      | a[href="https://mail.google.com/mail/?tab=wm"]       |
| PicsButton      | a[href*="https://www.google.com.ua/imghp?"]          |
| LoginButton     | a[href*="https://accounts.google.com/ServiceLogin?"] |
|                 |                                                      |