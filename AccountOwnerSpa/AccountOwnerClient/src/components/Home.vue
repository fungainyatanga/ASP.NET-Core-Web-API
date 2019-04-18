<template>
<p class = "homeText">
  Welcome To Account-Owner Application
</p>
</template>


<script>
import OwnerService from '@/api-services/owner.service'

export default {
name : 'Home',

};
</script>

<style scoped>
.homeText{
  font-size: 35px;
    color: red;
    text-align: center;
    position: relative;
    top:30px;
    text-shadow: 2px 2px 2px gray;
}

</style>
