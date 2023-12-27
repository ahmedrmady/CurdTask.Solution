


document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('CityId').addEventListener('change', function () {
        var selectedCity = this.value;
        var subCitiesList = document.getElementById('subCityList');

        subCitiesList.innerHTML = '';
        subCitiesList.innerHTML += '<option></option>';
        

        if (selectedCity !== '') {
            fetch('/cities/getSubCities?cityId=' + selectedCity)
                .then(response => response.json())
                .then(subCities => {
                    console.log(subCities);
                    subCities.forEach(subCity => {
                        console.log(subCity);
                        var option = document.createElement('option');
                        option.value = subCity.subCityId;
                        option.text = subCity.subCityName;
                        subCitiesList.appendChild(option);
                    });
                })
                .catch(error => console.error('Error:', error));
        }
    });

    //for subcity
    document.getElementById('subCityList').addEventListener('change', function () {
        var selectedSubCity = this.value;
        var villagesList = document.getElementById('villageList');

        var employeeSubCityOptin = document.getElementById('SubCityId');
        employeeSubCityOptin.value = selectedSubCity;

        villagesList.innerHTML = '';
        villagesList.innerHTML += '<option></option>';
       

        if (selectedSubCity !== '') {
            fetch('/cities/getVillages?subCityId=' + selectedSubCity)
                .then(response => response.json())
                .then(villages => {
                    console.log(villages);
                    villages.forEach(village => {
                        var option = document.createElement('option');
                        option.value = village.villageId;
                        option.text = village.villageName;
                        villagesList.appendChild(option);
                    });
                })
                .catch(error => console.error('Error:', error));
        }
    });

    //for villags
    document.getElementById('villageList').addEventListener('change', function () {
        var selectedVillag = this.value;

        var employeeVillageOptin = document.getElementById('VillageId');


        console.log(selectedVillag);
    
        if (selectedVillag !== '') {
            
            employeeVillageOptin.value = selectedVillag;
        }
    });
});
