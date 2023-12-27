

   

function deleteEmployee(id) {
    var isConfirmed = window.confirm('Are you sure you want to delete this employee?');
    if (isConfirmed) {
        $.ajax({
            method: 'GET',
            url: '/Employees/DeleteEmployee?empId=' + id,
            success: function (response) {
                console.log(response)
                var employeeToDelete = document.getElementById('emp' + id);
                console.log(employeeToDelete);
                if (employeeToDelete) {
                    // Delete the row
                    employeeToDelete.parentNode.removeChild(employeeToDelete);
                }
                location.reload();
            },
            error: function (error) {
                console.error('Error deleting record:', error);
            }
        });
    }
}