const userInput = document.getElementById('user-input');
const resultDisplay = document.getElementById('result');
const buttons = document.querySelectorAll('button');

let currentInput = '';
let lastInputWasOperator = false;

buttons.forEach(button => {
    button.addEventListener('click', () => handleButtonClick(button.textContent));
});

function handleButtonClick(buttonValue) {
    if (isOperator(buttonValue)) {

        handleOperator(buttonValue);

    } else if (buttonValue === '=') {

        calculateResult();

    } else if (buttonValue === 'C') {

        clearInput();

    } else if (buttonValue === '.') {
        handleCommaInput()

    } else {
        appendToInput(buttonValue);
    }
}

function handleCommaInput() {
    if (currentInput === '') {
        appendToInput('0,');
    } else if (!currentInput.includes('.') && !currentInput.match(/[+\-*/]$/)) {
        appendToInput('.');
    }
}


function isOperator(value) {
    return ['+', '-', '*', '/'].includes(value);
}

async function handleOperator(operator) {

    // If the last input was an operator, replace it with the new one
    if (lastInputWasOperator) {
        currentInput = currentInput.slice(0, -1);
    }

    // if last element is a comma, remove it
    if (currentInput.slice(-1) === '.') {
        currentInput = currentInput.slice(0, -1);
    }

    //cant start with an operator except for '-'
    if (currentInput === '' && operator !== '-') {
        return;
    }


    // Check if the input is in the format of 'number operator number' and calculate the result
    if (isInputInCalculationFormat(currentInput)) {
       await calculateResult();
    }

    appendToInput(operator);
    lastInputWasOperator = true;
}

function isInputInCalculationFormat(input) {
    // Regular expression to check if the input is in the format of 'number operator number'
    const regex = /^\d+(\.\d+)?[+\-*/]\d+(\.\d+)?$/;
    return regex.test(input);
}

async function calculateResult() {
    const expression = currentInput;
    if (expression) {

        // Split the expression into parts (number, operator, number)
        expressionParts = expression.split(/([+\-*/])/);

        // Get the first number
        const a = expressionParts[0];

        // Get the operator
        // encodeURIComponent() is used to encode special characters in the URL
        const operator = encodeURIComponent(expressionParts[1]); 

        // Get the second number
        const b = expressionParts[2];


        // Make an AJAX request to the server-side action method
       await fetch(`/Calculator/Calculate?a=${a}&symbol=${operator}&b=${b}`)
            .then(response => response.text())
            .then(result => {
                resultDisplay.textContent = result;
                currentInput = result.toString();
                console.log(currentInput);
            })
            .catch(error => console.error('Error:', error)); 
    }
}


function clearInput() {
    currentInput = '';
    lastInputWasOperator = false;
    userInput.value = currentInput;
    resultDisplay.textContent = '0';
}

function appendToInput(value) {
    lastInputWasOperator = false;
    currentInput += value;
    userInput.value = currentInput;
    console.log(currentInput);
}
