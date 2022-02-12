
import React from "react";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete";
import CircularProgress from "@material-ui/core/CircularProgress";
import GetWorldCities from '../services/WorldCitiesService';
import './WorldCitiesAutoComplete.css'

export default function Asynchronous() {
  const [open, setOpen] = React.useState(false);
  const [options, setOptions] = React.useState([]);
  const loading = open && options.length === 0;


  const onChangeHandle = async value => {
    if(value.length>2){
        const response = await GetWorldCities(value);   
        setOptions(response.data);
    }else{
        setOptions([{name:"Type at least 3 characters",country:"",subCountry:""}])
    }
  };

  React.useEffect(() => {
    if (!open) {
      setOptions([]);
    }
  }, [open]);

  return (
    
    <Autocomplete
        className="autoComplete"
      id="asynchronous-demo"
      open={open}
      onOpen={() => {
        setOpen(true);
      }}
      onClose={() => {
        setOpen(false);
      }}
      getOptionSelected={(option, value) => option.country === value.country|| option.name === value.name}
      getOptionLabel={option => option.name + ", "  +option.subCountry+ ", "  +option.country}
      options={options}
      loading={loading}
      renderInput={params => (
        <TextField
          {...params}
          label="Find a world city"
          variant="outlined"
          onChange={ev => {
            if (ev.target.value.length <3 || ev.target.value !== null) {
              onChangeHandle(ev.target.value);
            }
          }}
          InputProps={{
            ...params.InputProps,
            endAdornment: (
              <React.Fragment>
                {loading ? (
                  <CircularProgress color="inherit" size={20} />
                ) : null}
                {params.InputProps.endAdornment}
              </React.Fragment>
            )
          }}
        />
      )}
    />      
  );
}
