# scripting-to-framework

The code written here follows the 'From Scripting to Framework with Selenium and C#' course on TestAutomationU.com

## Challenges while following the course:

### 1. Need to install latest Visual Studio Preview

**Description:**\
    I ran into many issues in the beginning because I didn't have this version of Visual Studio installed.\
    In the course, links are provided to download .Net Core and VS Code, which is the software we are using.\
    We do not need to use Visual Studio, or even Visual Studio preview

**Issue 1:**\
    I faced many confusing errors in the first few days of this course trying to solve this issue.\
    I had installed the latest version of Visual Studio already (even though we don't need it for this course).\
    However, once I installed the latest version of Visual Studio Preview, all of those seemingly unrelated errors went away.

### 2. Mirror Card no longer displays Rarity element

**Description:**\
    In chapter 4 of the course, we start writing tests that explicity use the 'Mirror' card.\
    At the time of the recording, this card had the Rarity element displayed on the page.

**Bug:**\
    Currently, this element is no longer displayed on the page or in the DOM for the 'Mirror' card.\
    The same thing is true for the 'Heal Spirit' card.

**Issue 2:**\
    As a result, both of these tests will fail the 'Card_headers_are_correct_on_Card_Details_Page' test.

### 3. User_opens_Google_Play test method _should_ fail

**Description:**\
    In chapter 6, we begin writing a new suite of tests, the Copy Deck suite.\
    At the time of the recording, there was a bug in the <https://statsroyale.com> website.\
    That same bug still exists in the site today

**Bug:**\
    On the "Copy the Deck" page, the 'Get it on Google Play' button redirects to the App store rather than the Google Play store.

**Note:**\
    This bug will cause the User_opens_Google_Play test method to fail.\
    However, this test _should_ fail, since it's catching the bug.

### 4. Ads on the pages cause several errors

**Description:**\
    At the time of the course recording, the pages didn't have all the ads that exist today.\
    Currently, there are several ads and a video that are on the homepage and several of the card pages.\
    - see Chapter 5 from 4:15-4:42 for an example of the pages not containing all the ads.

**Issue 4.1:**\
    Element Click Intercepted Exception\
    Two of the ads, the InfoLinks ad and the video, sometimes steal the click from various cards, if they load faster than the card.

**Issue 4.2:**\
    The InfoLinks ad is an iframe and has a dynamic ID.\
    I have been unable to figure out how to get Selenium to click the X-button and close it.

**Issue 4.3:**\
    The video eventually loads an X-button, but it takes a while to appear.\
    Also, there is an add that loads over the video.\
    I can't easily inspect the video in the DOM.\
    I have been unable to figure out how to get Selenium to close the video

**Issue 4.4**\
    I think these ads, especially the video, cause a huge strain on my system.\
    That leads into the challenges listed in the next section.
        

## Extra challenges because of hardware

**Description:**\
    The following challenges are things I ran into because of the computer I am using.

### 5. HTTP timeout causes tests to fail

**Description:**\
    Sometimes tests fail with the following error:

> The HTTP request to the remote WebDriver server for URL http://localhost: ... timed out after 60 seconds

**Issue 5:**\
    I couldn't find a coding solution how to solve this.\
    After installing the necessary software and pulling the repository on a borrowed laptop, I was able to see a huge reduction of this error.\
    I only saw it again on the borrowed laptop when I started trying to run the tests in parallel with 3 test workers.

### 6. Couldn't run tests in parallel

**Description:**\
    My machine is unable to handle running these tests in parallel.

**Issue 6:**\
    If I tried setting the test workers to 2, all the tests fail with the HTTP request error.\
    Also, running all 101 tests for just the Card_headers_are_correct_on_Card_Details_Page test takes about 2 hours.\
    that makes it difficult to debug and find the real failing tests.

### 7. Other general flaky errors because my machine is too slow

**Description:**\
    I get errors on random tests because my machine is too slow.\
    Those same tests will pass on a different run, but then others will fail.\
    Some of those other errors include:\
    + Stale Reference Exception\
    + Timeouts after 10 seconds on random elements
