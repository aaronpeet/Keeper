<template>
  <div class="card" @click="getKeepById(keep.id)" data-toggle="modal" :data-target="'#keepDetailsModal' + keep.id" title="View keep details">
    <img class="card-img rounded shadow" :src="keep.img" alt="keep image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <h5 class="card-title text-light text-left">
        {{ keep.name }}
      </h5>
      <router-link :to="{ name: 'About', params: {id: keep.creatorId} }" class="nav-link">
        <img class="rounded-pill" :src="keep.creator.picture" alt="keep creator image">
      </router-link>
    </div>
  </div>
</template>

<script>
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },

  setup() {
    return {
      async getKeepById(id) {
        try {
          await keepsService.getKeepById(id)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.rounded-pill{
    max-height: 40px;
}
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
