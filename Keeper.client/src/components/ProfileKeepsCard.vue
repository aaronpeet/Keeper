<template>
  <div class="card">
    <img class="card-img rounded shadow action" :src="keep.img" alt="keep image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <h5 class="card-title text-light text-left">
        {{ keep.name }}
      </h5>
      <button class="btn btn-danger" @click="deleteKeep(keep.id)">
        Remove
      </button>
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
      async deleteKeep(id) {
        try {
          await keepsService.deleteKeep(id)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
