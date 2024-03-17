document.addEventListener("DOMContentLoaded", function() {
    // Function to update date and time
    function updateDateTime() {
        let dateElement = document.getElementById("date");
        let timeElement = document.getElementById("time");
        
        dateElement.innerHTML = new Date().toLocaleDateString();
        timeElement.innerHTML = new Date().toLocaleTimeString([], { hour12: true }).toUpperCase();
    }

    // Call updateDateTime initially to set the date and time
    updateDateTime();

    // Call updateDateTime every second to update the time
    setInterval(updateDateTime, 1000);
});


document.addEventListener("DOMContentLoaded", function() {
    
    // DOM Elements 
  //  let boothMemberIdInput = document.getElementById("boothMemberId");
  //  let aadharIdInput = document.getElementById("aadharId");
    let submitButton1 = document.getElementById("submitButton");

    let adminInputField = document.getElementById('adminId');
    let stateInputField = document.getElementById('state');
    let districtInputField = document.getElementById('district');
    let adminAadharIdInputField = document.getElementById('adminAadharId');
    let submitButton2 = document.querySelector("#districtAdminForm input[type='submit']");

    // Error messages 
    let districtAdminErrorMessage = "Please enter all the details";
    let boothMemberLoginErrorMessage = "Please enter all the details";

    // Function to validate District Admin/LAC ID form submission
    function validateDistrictAdminForm(event) {
        event.preventDefault();

        let adminInputValue = adminInputField.value;
        let stateInputValue = stateInputField.value;
        let districtInputValue = districtInputField.value;
        let adminAadharIdInputValue = adminAadharIdInputField.value;

        if (adminInputValue === '' || stateInputValue === '' || districtInputValue === '' || adminAadharIdInputValue === '') {
            alert(districtAdminErrorMessage);
        } else {
            alert("Login successful");
        }
    }

    // Function to validate Booth Member Login form submission
    function handleSubmit(event) {
        event.preventDefault();

        let boothMemberId = boothMemberIdInput.value;
        let aadharId = aadharIdInput.value;

        if (boothMemberId === "" || aadharId === "") {
            alert(boothMemberLoginErrorMessage);
            return;
        } else if (boothMemberId.length !== 10) {
            alert("Booth Member ID is incorrect. It should be 10 characters long.");
            return;
        } else if (aadharId.length !== 12) {
            alert("Aadhar card is incorrect. It should be 12 characters long.");
            return;
        } else {
            alert("Login successful");
            return;
        }
    }

    // Event listeners
    submitButton1.addEventListener("click", handleSubmit);
    document.getElementById("districtAdminForm").addEventListener("submit", validateDistrictAdminForm);

    // Function to allow only numbers
    function allowNumbers(event) {
        let charCode = event.charCode;
        if (!(charCode >= 48 && charCode <= 57)) {
            event.preventDefault();
        }
    }

    // Event listeners for input fields
    //boothMemberIdInput.addEventListener("keypress", function(event) {
    //    allowNumbers(event);
    //    if (boothMemberIdInput.value.length >= 10) {
    //        event.preventDefault();
    //    }
    //});
    //aadharIdInput.addEventListener("keypress", function(event) {
    //    allowNumbers(event);
    //    if (aadharIdInput.value.length >= 12) {
    //        event.preventDefault();
    //    }
    //});
    //adminInputField.addEventListener("keypress", function(event) {
    //    allowNumbers(event);
    //    if (adminInputField.value.length >= 6) {
    //        event.preventDefault();
    //    }
    //});
    //stateInputField.addEventListener("keypress", function(event) {
    //    if (!((event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122) || event.charCode === 32)) {
    //        event.preventDefault();
    //    }
    //});
    //districtInputField.addEventListener("keypress", function(event) {
    //    if (!((event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122) || event.charCode === 32)) {
    //        event.preventDefault();
    //    }
    //});
    //adminAadharIdInputField.addEventListener("keypress", function(event) {
    //    allowNumbers(event);
    //    if (adminAadharIdInputField.value.length >= 12) {
    //        event.preventDefault();
    //    }
    //});
});
